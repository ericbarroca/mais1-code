using Libs.Models;
using Libs.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TutorRepository>();
builder.Services.AddSingleton<PetRepository>();
builder.Services.AddSingleton<VacinaRepository>();
builder.Services.AddSingleton<ConsultaRepository>();

builder.Services.AddCors(options=>{
    options.AddDefaultPolicy(policy=>{
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();

    });
});

var app = builder.Build();
app.UseCors();

app.MapGet("/", () => "Cadrasto de Pet");

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


app.MapDelete("/pet/{id}", (PetRepository repo, int id) =>
{

    var pet = repo.Get(id);

    if (pet is null)
    {
        return Results.NotFound();
    }

    if (!repo.Remove(id))
    {
        return Results.BadRequest();
    }

    return Results.NoContent();
});

app.MapPut("/pet/{id}", (PetRepository repo, int id, Pet pet) =>
{

    if (pet.ID != id)
    {
        return Results.BadRequest("Pet ID diferente de id da rota");
    }

    if (id == 0)
    {
        return Results.BadRequest("O pet não pode ter ID 0");
    }

    if (pet.TutorID is null)
    {
        return Results.BadRequest("Tutor não preenchido");
    }

    var pet_found = repo.Get(id);

    if (pet_found is null)
    {
        return Results.NotFound();
    }

    if (repo.Upsert(pet))
    {
        return Results.BadRequest();
    }

    return Results.Accepted("/tutor/{id}/pets", pet);

});

app.MapGet("/pets/{id}/vacinas", (PetRepository petRepo, VacinaRepository vacRepo, int id) =>
{

    var pet = petRepo.Get(id);

    if (pet is null)
    {
        return Results.NotFound();
    }

    var vacinas = pet.Vacinas(vacRepo);

    return Results.Ok(vacinas);
});

app.MapPost("/pets/{id}/vacinas", (PetRepository petRepo, VacinaRepository vacRepo, int id, Vacina vacina) => {
    var pet = petRepo.Get(id);
    if (pet is null) {
        return Results.NotFound();
    }

    if (vacina.ID != 0)
    {
        return Results.BadRequest("A vacina não pode ter ID diferente de 0");
    }

    if(!pet.UpsertVacina(vacRepo, vacina)) {
        return Results.BadRequest();
    }
    
    return Results.Created("/pets/{id}/vacinas", vacina);
});


app.MapGet("/pets/{id}/consultas", (PetRepository petRepo, ConsultaRepository consultaRepo, int id) =>
{

    var pet = petRepo.Get(id);

    if (pet is null)
    {
        return Results.NotFound();
    }

    var consultas = pet.Consultas(consultaRepo);

    return Results.Ok(consultas);
});

app.MapPost("/pets/{id}/consultas", (PetRepository petRepo, ConsultaRepository consultaRepo, int id, Consulta consulta) => {
    var pet = petRepo.Get(id);
    
    if (pet is null) {
        return Results.NotFound();
    }

    if (consulta.ID != 0)
    {
        return Results.BadRequest("A consulta não pode ter ID diferente de 0");
    }

    if(!pet.UpsertConsulta(consultaRepo, consulta)) {
        return Results.BadRequest();
    }
    
    return Results.Created("/pets/{id}/consultas", consulta);
});

app.MapDelete("/consultas/{id}", (ConsultaRepository consultaRepo, int id) =>
{

    var consulta = consultaRepo.Get(id);

    if (consulta is null)
    {
        return Results.NotFound();
    }

    if (!consultaRepo.Remove(id))
    {
        return Results.BadRequest();
    }

    return Results.NoContent();
});

app.Run();
