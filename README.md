# EventEase

A Blazor WebAssembly application for discovering events, registering attendees, and
tracking attendance. This repository is the combined submission for the EventEase
course project, bringing together the component, routing, validation, performance, and
advanced-feature activities into one app.

## Tech stack

- **.NET 9 / Blazor WebAssembly** (standalone)
- **Bootstrap 5** for styling
- Data-annotation validation, dependency-injected services for state management

## Run it locally

Prerequisites: [.NET SDK 6.0+](https://dotnet.microsoft.com/download) and VS Code with
the **C# Dev Kit** extension.

```bash
cd EventEase
dotnet restore
dotnet run           # then open the URL shown (e.g. http://localhost:5199)
# or, for live reload while editing UI:
dotnet watch run
```

## Features (mapped to the rubric)

| Rubric item | Where it lives |
|---|---|
| **Event Card component** with fields + two-way data binding | `Components/EventCard.razor` (bindable `@bind-Event`, `@bind` inputs) |
| **Routing** | `Pages/EventDetails.razor` (`@page "/event/{Id:int}"`), `Pages/Register.razor` (`@page "/register/{Id:int}"`), `App.razor` `<NotFound>` |
| **Performance / validation / routing errors** | `Models/Event.cs` + `Models/Registration.cs` (data annotations, custom `FutureDateAttribute`); invalid-id guards in `EventDetails`/`Register`; `<NotFound>` fallback |
| **Advanced features** | Registration form with validation (`Register.razor`), user-session state (`Services/UserSessionService.cs`), Attendance Tracker (`Pages/Attendance.razor` + `Services/RegistrationService.cs`) |

### Pages

- `/` — **Home**: lists events, each rendered with the reusable `EventCard`.
- `/event/{id:int}` — **Event Details**: routed by id, shows registration counts, handles unknown ids.
- `/register/{id:int}` — **Registration Form**: `EditForm` + `DataAnnotationsValidator` with inline messages; starts a user session on submit.
- `/attendance` — **Attendance Tracker**: check attendees in; live counts via a shared singleton service.
- `/counter` — retained from the debugging activity (for-loop + `Console.WriteLine` tracing).

## How Copilot assisted in each step

> Required summary — how Microsoft Copilot supported development.

1. **Event Card component & two-way binding.** Copilot scaffolded the initial
   `EventCard.razor`, suggesting the `[Parameter]` + paired `EventChanged`
   `EventCallback` pattern that makes the component usable with `@bind-Event`, and
   generated the `@bind`/`@bind:event="oninput"` inputs for live editing.

2. **Routing.** Copilot proposed the `@page "/event/{Id:int}"` and
   `/register/{Id:int}` route templates with typed route constraints, and reminded me
   to wire navigation links with the correct interpolated `href` values.

3. **Debugging.** When the Counter loop didn't behave as expected, Copilot suggested the
   `Console.WriteLine` trace statements (before/inside/after the loop) that surfaced the
   iteration values in the VS Code terminal.

4. **Performance & validation.** Copilot recommended data-annotation attributes
   (`[Required]`, `[EmailAddress]`, `[StringLength]`) and helped author the custom
   `FutureDateAttribute`. It also flagged that details/registration pages should guard
   against non-existent ids, and that `App.razor` should keep a `<NotFound>` fallback to
   handle routing errors gracefully.

5. **Advanced features (form, state, attendance).** Copilot generated the `EditForm`
   with `DataAnnotationsValidator`/`ValidationSummary`/`ValidationMessage`, suggested the
   singleton services plus an `OnChange` event for state management across components, and
   scaffolded the Attendance Tracker table with per-attendee check-in toggles.

6. **Documentation.** Copilot helped draft this README and the inline code comments that
   explain each rubric mapping.

> Note: all Copilot output was reviewed, adjusted, and verified with `dotnet build`
> (0 warnings, 0 errors) and by running the app before committing.
