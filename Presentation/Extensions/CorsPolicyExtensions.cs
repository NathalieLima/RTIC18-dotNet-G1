namespace CleanArchitecture.WebAPI.Extensions;

public static class CorsPolicyExtensions
{
    public static void ConfigureCorsPolicy(this IServiceCollection services)
    {
        //Define politica padrao
        services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(builder => builder
                .AllowAnyOrigin()//qualquer origem
                .AllowAnyMethod()//qualquer metodo
                .AllowAnyHeader());//qualquer cabecalho acessa a API -> essa é uma politica sem restricao
        });
    }
}
