using Semana1.Domain;
using ClassDaniel.Domain;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string Profiles()
{
    return AlanPrates.View() + Lorena.View() + Daniel.ViewProfile();
}

string ListarHabilidadesAlanPrates()
{
    return AlanPrates.ListarHabilidades();
}

app.MapGet("/", () => Profiles());

app.MapGet("/user/", () => AlanPrates.View());

app.MapGet("/lorena/", () => Lorena.View());

app.MapGet("/daniel/", () => Daniel.ViewProfile());

app.MapGet("/alanprates", () => ListarHabilidadesAlanPrates());

app.Run();
