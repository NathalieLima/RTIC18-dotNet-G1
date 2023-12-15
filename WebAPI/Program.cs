using Semana1.Domain;
using ClassDaniel.Domain;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string Profiles(){

    return User.View() + Lorena.View() + Daniel.ViewProfile();
}

app.MapGet("/", () => Profiles());
app.MapGet("/user/", () => User.View());

app.MapGet("/lorena/", () => Lorena.View());//Rota lorena
app.MapGet("/daniel/", () => Daniel.ViewProfile());
app.Run();
