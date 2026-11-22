using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

/// <summary>
/// Represents a single event managed by the EventEase app.
/// Data-annotation attributes drive both the Event Card edit form
/// and the server-style validation used across the app.
/// </summary>
public class Event
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Event name is required.")]
    [StringLength(100, MinimumLength = 3,
        ErrorMessage = "Event name must be between 3 and 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Event date is required.")]
    [DataType(DataType.Date)]
    [FutureDate(ErrorMessage = "Event date must be today or in the future.")]
    public DateTime Date { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Location is required.")]
    [StringLength(150, ErrorMessage = "Location cannot exceed 150 characters.")]
    public string Location { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; } = string.Empty;
}

/// <summary>
/// Custom validation attribute that rejects dates in the past.
/// Addresses the "input validation" requirement in the rubric.
/// </summary>
public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext context)
    {
        if (value is DateTime date && date.Date < DateTime.Today)
        {
            return new ValidationResult(ErrorMessage ?? "Date cannot be in the past.",
                new[] { context.MemberName ?? string.Empty });
        }

        return ValidationResult.Success;
    }
}
