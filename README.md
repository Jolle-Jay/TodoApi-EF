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
2. Create a MySQL database:
```sql
CREATE DATABASE tododb;
USE tododb;

CREATE TABLE todos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    title VARCHAR(255) NOT NULL,
    isCompleted BOOLEAN DEFAULT FALSE,
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP
);
```
3. Copy `appsettings.example.json` to `appsettings.json` and fill in your MySQL credentials
4. Run:
```bash
dotnet run
```