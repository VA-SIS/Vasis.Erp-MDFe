using Microsoft.Extensions.DependencyInjection;
using Vasis.Erp.Facil.Application.Interfaces;
using Vasis.Erp.Facil.Application.Services;
using Vasis.Erp.Facil.Services.Cadastros;

namespace Vasis.Erp.Facil.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEmpresaService, EmpresaService>();
        return services;
    }
}
