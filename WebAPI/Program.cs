using Semana1.Domain;
using ClassDaniel.Domain;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => {
    var strRotaPrincipal = new StringBuilder();
    strRotaPrincipal.AppendLine("Resumo das habilidades da equipe:");
    strRotaPrincipal.AppendLine();
    //O resumo de cada membro
    strRotaPrincipal.AppendLine(Lorena.View());
    strRotaPrincipal.AppendLine(Daniel.ViewProfile());
    strRotaPrincipal.AppendLine(AlanPrates.ListarHabilidades());

    // Soma geral da equipe
    var totalGeral = Lorena.TotalEstrelas + Daniel.TotalEstrelas + AlanPrates.TotalEstrelas;
    strRotaPrincipal.AppendLine();
    strRotaPrincipal.AppendLine($"Soma geral da equipe: {totalGeral}");

    return strRotaPrincipal.ToString();
});

app.MapGet("/lorena/", () => Lorena.View());

app.MapGet("/daniel/", () => Daniel.ViewProfile());

app.MapGet("/alanprates", () => AlanPrates.ListarHabilidades());

app.Run();
