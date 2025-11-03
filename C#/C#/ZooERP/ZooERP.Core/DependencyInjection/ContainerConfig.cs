using Microsoft.Extensions.DependencyInjection;
using ZooERP.Core.Interfaces;
using ZooERP.Core.Services;
namespace ZooERP.Core.DependencyInjection
{
    public static class ContainerConfig
    {
        public static IServiceProvider Configure()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
            services.AddSingleton<IZooService, ZooService>();
            return services.BuildServiceProvider();
        }
    }
}