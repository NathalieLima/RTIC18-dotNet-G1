
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Application.Services;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<ISistemaService, SistemaService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDbContext<ResTIConnectContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("ResTIConnect");

    var serverVersion = ServerVersion.AutoDetect(connectionString);

      options.UseMySql(connectionString, serverVersion);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
