using Helpers;

namespace Events;

public class PlayerMovedEvent : EnhancedMessage
{
    public Guid GameId { get; set; }
    public string PlayerId { get; set; }
    public Move Move { get; set; }
}