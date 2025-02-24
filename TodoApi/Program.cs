var builder = WebApplication.CreateBuilder(args);
<<<<<<< HEAD
builder.Services.AddSingleton<Biblioteca>();

var app = builder.Build();

app.MapGet("", () => "Biblioteca");

app.MapGet("/livros", (Biblioteca biblioteca) => biblioteca.ListarLivros());

app.MapGet("/livros/{nome}", (Biblioteca biblioteca, string nome) =>
{
    var livro = biblioteca.BuscarLivro(nome);

    if (livro is null) {
        return Results.NotFound();
    }

    return Results.Ok(livro);
});

app.MapPost("/livros", (Biblioteca biblioteca, Livro livro) =>
{
    var livroExistente = biblioteca.BuscarLivro(livro.Nome);

    if (!(livroExistente is null)) {
        return Results.BadRequest("Livro ja existe");
    }

    biblioteca.Upsert(livro);

    return Results.Created();
});

app.MapPut("/livros", (Biblioteca biblioteca, Livro livro) =>
{
    var livroExistente = biblioteca.BuscarLivro(livro.Nome);

    if (livroExistente is null) {
        return Results.BadRequest("Livro não existe");
    }

    biblioteca.Upsert(livro);

    return Results.Accepted();
});

app.MapDelete("/livros/{nome}", (Biblioteca biblioteca, string nome)=>{
    if (biblioteca.Delete(nome) == true) {
        return Results.Ok();
    }
    return Results.NotFound();
});
=======
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
>>>>>>> ebf331e7209f3f1338a0c05da814563eded71451

app.Run();
