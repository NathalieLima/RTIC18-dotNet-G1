using Semana1.Domain;
using ClassDaniel.Domain;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/user/", () => User.View());

app.MapGet("/lorena/", () => Lorena.View());//Rota lorena
app.MapGet("/daniel/", () => Daniel.ViewProfile());
app.Run();
