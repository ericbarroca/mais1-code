using Libs.Models;
using Libs.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TutorRepository>();
builder.Services.AddSingleton<PetRepository>();
var app = builder.Build();

app.MapGet("/tutor/{id}", (TutorRepository repo, int id) =>
{
    var tutor = repo.Get(id);

    if (tutor is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(tutor);
});

app.MapGet("/tutor/{id}/pets", (TutorRepository repo, PetRepository petRepo, int id) =>
{
    var tutor = repo.Get(id);

    if (tutor is null)
    {
        return Results.NotFound();
    }

    var pets = tutor.Pets(petRepo);

    return Results.Ok(pets);
});

app.MapPost("/tutor/{id}/pets", (TutorRepository repo, PetRepository petRepo, int id, Pet pet) =>
{

    var tutor = repo.Get(id);

    if (tutor is null)
    {
        return Results.NotFound();
    }

    if (pet.ID != 0)
    {
        return Results.BadRequest("O pet não pode ter ID diferente de 0");
    }

    pet.TutorID = tutor.Documento;

    if (!petRepo.Upsert(pet))
    {
        return Results.BadRequest();
    }

    return Results.Created("/tutor/{id}/pets", pet);

});

app.Run();
