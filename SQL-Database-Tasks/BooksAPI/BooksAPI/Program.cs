using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksDb>(opt => opt.UseInMemoryDatabase("BookList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/Books", async (BooksDb db) =>
    await db.books.ToListAsync());

app.MapGet("/Books/{id}", async (int id, BooksDb db) =>
    await db.books.FindAsync(id)
        is Books book
            ? Results.Ok(book)
            : Results.NotFound());

app.MapPost("/Books", async (Books b, BooksDb db) =>
{
    db.books.Add(b);
    await db.SaveChangesAsync();

    return Results.Created($"/Books/{b.Id}", b);
});

app.MapPut("/Books/{id}", async (int id, Books inputBook, BooksDb db) =>
{
    var books = await db.books.FindAsync(id);

    if (books is null) return Results.NotFound();

    books.Name = inputBook.Name;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Books/{id}", async (int id, BooksDb db) =>
{
    if (await db.books.FindAsync(id) is Books book)
    {
        db.books.Remove(book);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();

public class Books
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

class BooksDb : DbContext
{
    public BooksDb(DbContextOptions<BooksDb> options)
        : base(options) { }

    public DbSet<Books> books => Set<Books>();
}