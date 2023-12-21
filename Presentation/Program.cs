using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence;
using CleanArchitecture.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

CreateDatabase(app);

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();
app.MapControllers();
app.Run();

static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    //Se o banco de dados existir e possuir alguma tabela -> nao faz nenhuma acao
    //Se o banco de dados existir mas nao tem nenhuma tabela -> vai criar o esquema definido na entidade no modelo de dominio
    //Se nao existir banco de dados ele vai criar os dois
    dataContext?.Database.EnsureCreated();
}