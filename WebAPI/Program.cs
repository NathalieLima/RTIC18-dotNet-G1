using Semana1.Domain;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string TesteSimples()
{
    return User.View();
}

app.MapGet("/", () => TesteSimples());

app.MapGet("/daniel", () => Daniel.ViewProfile());
app.Run();
