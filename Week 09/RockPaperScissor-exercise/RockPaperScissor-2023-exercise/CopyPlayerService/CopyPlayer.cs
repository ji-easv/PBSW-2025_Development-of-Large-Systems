using System.Diagnostics;
using Events;
using Helpers;
using Serilog;

namespace CopyPlayerService;

public class CopyPlayer : IPlayer
{
    private const string PlayerId = "The Copy Cat";
    private readonly Queue<Move> _previousMoves = new Queue<Move>();

    public PlayerMovedEvent MakeMove(GameStartedEvent e)
    {
        using var activity = Monitoring.ActivitySource.StartActivity("MakeMove", ActivityKind.Producer, e.ActivityContext);
        
        Move move = Move.Paper;
        if (_previousMoves.Count > 2)
        {
            move = _previousMoves.Dequeue();
        }
        Log.Logger.Debug("Player {PlayerId} has decided to perform the move {Move}", PlayerId, move);

        var moveEvent = new PlayerMovedEvent
        {
            GameId = e.GameId,
            PlayerId = PlayerId,
            Move = move
        };
        
        moveEvent.PropagateContext(activity);
        return moveEvent;
    }

    public void ReceiveResult(GameFinishedEvent e)
    {
        using var activity = Monitoring.ActivitySource.StartActivity("ReceiveResult", ActivityKind.Consumer, e.ActivityContext);
        
        var otherMove = e.Moves.SingleOrDefault(m => m.Key != PlayerId).Value;
        Log.Logger.Debug("Received result from game {GameId} - other player played {Move} queue now has {QueueSize} elements", e.GameId, otherMove, _previousMoves.Count);
        _previousMoves.Enqueue(otherMove);
    }

    public string GetPlayerId()
    {
        return PlayerId;
    }
}