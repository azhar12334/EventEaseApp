using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

/// <summary>
/// Captures a user's registration for an event. Used by the
/// Registration Form (with validation) and the Attendance Tracker.
/// </summary>
public class Registration
{
    public int EventId { get; set; }

    [Required(ErrorMessage = "Your name is required.")]
    [StringLength(80, MinimumLength = 2,
        ErrorMessage = "Name must be between 2 and 80 characters.")]
    public string AttendeeName { get; set; } = string.Empty;

    [Required(ErrorMessage = "An email address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    /// <summary>Marked true once the attendee is confirmed present.</summary>
    public bool HasAttended { get; set; }

    public DateTime RegisteredAt { get; set; } = DateTime.Now;
}
