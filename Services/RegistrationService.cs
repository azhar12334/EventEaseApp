using EventEase.Models;

namespace EventEase.Services;

/// <summary>
/// Stores registrations and powers the Attendance Tracker.
/// Singleton so registrations persist while the app is running.
/// </summary>
public class RegistrationService
{
    private readonly List<Registration> _registrations = new();

    public event Action? OnChange;

    public IReadOnlyList<Registration> GetAll() => _registrations;

    public IEnumerable<Registration> GetForEvent(int eventId) =>
        _registrations.Where(r => r.EventId == eventId);

    public void Register(Registration registration)
    {
        _registrations.Add(registration);
        OnChange?.Invoke();
    }

    /// <summary>Toggles attendance for the Attendance Tracker.</summary>
    public void ToggleAttendance(Registration registration)
    {
        registration.HasAttended = !registration.HasAttended;
        OnChange?.Invoke();
    }

    public int AttendedCount(int eventId) =>
        _registrations.Count(r => r.EventId == eventId && r.HasAttended);
}
