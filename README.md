Todo API - Entity FrameWork

Same TODO api as TodoApi but built with ENtity FrameWork Core instead of Raw SQL.

Key difference
Raw SQL version: you write every query manually.
EF Generates the SQL automatically

Tech Stack
- C# / .NET 10
- Entity Framework Core 9
- Pomelo.EntityFrameWorkCore.MySql
- MySQL

Endpoints
| Method | URL | Description |

| GET | /todos | Get all todos |
| POST | /todos | Create a new todo |
| PUT | /todos/{id} | Update a todo |
DELETE | /todos/{id} | Delete a todo |

Setup
1. Clone the repo
2. Copy `appsettings.example.json` to `appsettings.json` and fill in your MySQL credentials
3. Run:
```bash
dotnet run
```