using Helpers;

namespace Events;

public class GameFinishedEvent : EnhancedMessage
{
    public Guid GameId { get; set; }
    public string? WinnerId { get; set; }
    public Dictionary<string, Move> Moves { get; set; } = new Dictionary<string, Move>();
}