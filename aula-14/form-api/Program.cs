var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UserService>();
builder.Services.AddCors(options=>{
    options.AddDefaultPolicy(policy=>{
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();

    });
});

var app = builder.Build();
app.UseCors();


app.MapGet("/", () =>  {
    return Results.Ok();
});

app.MapPost("/login", (UserService service, User user) => {

    if(service.Login(user)) {
        return Results.Created("/", user);
    }

    return Results.Unauthorized();
});

app.Run();
