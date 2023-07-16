using LivroApi;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var livros = new List<Livro>
{
    new Livro("Fundamentos C#", 2020, "1a"),
    new Livro("MinimalAPI", 2021, ".NET")
};

app.MapGet("/livros", () =>
{
    return Results.Ok(livros);
})
.WithName("livros")
.WithOpenApi();


app.MapGet("/livroPorTitulo", ([FromQuery] string titulo) =>
{
    var livro = livros.Where(x => x.Titulo.ToLower().Contains(titulo.ToLower()));
    if(livro == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(livro);
});

app.MapPost("/adicionaLivro", ([FromBody] Livro livro) =>
{
    livros.Add(livro);
    return Results.Ok(livro);
});


app.MapDelete("/livros", () =>
{
    livros = new List<Livro>();
    return Results.Ok(livros);  

});
app.Run();
