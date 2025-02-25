using Helpers;

namespace Events;

public class GameStartedEvent : EnhancedMessage
{
    public Guid GameId { get; set; }
}