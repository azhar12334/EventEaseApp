using EventEase.Models;

namespace EventEase.Services;

/// <summary>
/// In-memory store of events. Registered as a singleton so the same
/// list is shared across every page (simple state management).
/// </summary>
public class EventService
{
    private readonly List<Event> _events = new()
    {
        new Event
        {
            Id = 1,
            Name = "Tech Conference 2026",
            Date = DateTime.Today.AddDays(14),
            Location = "Seattle Convention Center",
            Description = "A full day of talks on cloud, AI, and .NET."
        },
        new Event
        {
            Id = 2,
            Name = "Community Hackathon",
            Date = DateTime.Today.AddDays(30),
            Location = "Downtown Innovation Hub",
            Description = "48 hours of building with fellow developers."
        },
        new Event
        {
            Id = 3,
            Name = "Product Launch Gala",
            Date = DateTime.Today.AddDays(45),
            Location = "Grand City Ballroom",
            Description = "An evening celebrating our newest release."
        }
    };

    public IReadOnlyList<Event> GetEvents() => _events;

    public Event? GetEvent(int id) => _events.FirstOrDefault(e => e.Id == id);

    public void AddEvent(Event newEvent)
    {
        newEvent.Id = _events.Count == 0 ? 1 : _events.Max(e => e.Id) + 1;
        _events.Add(newEvent);
    }
}
