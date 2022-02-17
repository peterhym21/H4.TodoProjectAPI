using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using TodoWebAPI;
using TodoWebAPI.Context;
using TodoWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

string domain = $"https://{builder.Configuration["Auth0:Domain"]}/";

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = domain;
        options.Audience = builder.Configuration["Auth0:Audience"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = ClaimTypes.NameIdentifier
        };
    });


builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("WritePolicy", p => p.RequireAuthenticatedUser().RequireClaim("permissions", "todo:write"));
    o.AddPolicy("ReadPolicy", p => p.RequireAuthenticatedUser().RequireClaim("permissions", "todo:read")); 
    o.AddPolicy("CreatePolicy", p => p.RequireAuthenticatedUser().RequireClaim("permissions", "todo:create"));
    o.AddPolicy("DeletePolicy", p => p.RequireAuthenticatedUser().RequireClaim("permissions", "todo:delete"));
});

builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();


var app = builder.Build();



#region APICall

app.MapGet("/", () => "Hello World!");

app.MapGet("/todoitems", async (TodoDb db) =>
    await db.Todos.Where(t => t.Completed == false).ToListAsync()).RequireAuthorization("ReadPolicy");

app.MapGet("/todoitems/all", async (TodoDb db) =>
    await db.Todos.ToListAsync()).RequireAuthorization("ReadPolicy");

app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is TodoWebAPI.Models.Todo todo
        ? Results.Ok(todo)
        : Results.NotFound()).RequireAuthorization("ReadPolicy");



app.MapPost("/todoitems", async (TodoWebAPI.Models.Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
}).RequireAuthorization("CreatePolicy");



app.MapPut("/todoitems/{id}", async (int id, TodoWebAPI.Models.Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.Completed = inputTodo.Completed;
    todo.Description = inputTodo.Description;
    todo.Priority = inputTodo.Priority;

    await db.SaveChangesAsync();

    return Results.NoContent();
}).RequireAuthorization("WritePolicy");



app.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is TodoWebAPI.Models.Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
}).RequireAuthorization("DeletePolicy");

#endregion




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(o => {
    o.AllowAnyOrigin();
    o.AllowAnyHeader();
    o.AllowAnyMethod();
});


app.UseAuthentication();
app.UseAuthorization();

app.Run();

