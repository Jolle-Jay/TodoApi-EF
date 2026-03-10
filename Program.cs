using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//hämtar connectionString från appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// registrerar dbContext med MySql
builder.Services.AddDbContext<TodoDb>(options =>
options.UseMySql(connectionString, new MySqlServerVersion(new Version(9, 5, 0))));

var app = builder.Build();

app.MapGet("/todos", async (TodoDb db) =>
await db.Todos.ToListAsync());

app.MapPost("/todos", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();
    return Results.Ok(todo);
});

app.MapPut("/todos/{id}", async (int id, Todo updatedTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo == null) return Results.NotFound();
    todo.Title = updatedTodo.Title;
    todo.IsCompleted = updatedTodo.IsCompleted;
    await db.SaveChangesAsync();
    return Results.Ok(todo);

});

app.MapDelete("/todos/{id}", async (int id, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo == null) return Results.NotFound();
    db.Todos.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();

});

app.Run();

class Todo
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public bool IsCompleted { get; set; }
}

//dbContext - kopplingen mellan C# och Databasen
class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options) : base(options) { }
    public DbSet<Todo> Todos { get; set; }
};
