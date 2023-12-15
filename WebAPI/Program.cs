using Semana1.Domain;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string ListarHabilidadesAlanPrates()
{
    return AlanPrates.ListarHabilidades();
}

app.MapGet("/alanprates", () => ListarHabilidadesAlanPrates());

app.Run();