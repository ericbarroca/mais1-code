var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options=>{
    options.AddDefaultPolicy(policy=>{
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();

    });
});

var app = builder.Build();
app.UseCors();


app.MapGet("/dados", () => new Exemplo() {
    ID = 1,
    Nome = "ABC"
});

app.MapPost("/dados", (Exemplo dados) => {
    dados.ID = 2;
    return Results.Created("/dados", dados);
});

app.Run();
