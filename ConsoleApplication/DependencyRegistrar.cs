using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreConsole.Common;
using NetCoreConsole.Core;
using NetCoreConsole.PostgreSql;
using NetCoreConsole.Service;
using NetCoreConsole.Service.Core;

namespace ConsoleApplication
{
    public static class DependencyRegistrar
    {
        public static void RegisterDependencies()
        {
            
            ServiceCollection collection = new ServiceCollection();

            var configuration = BuildConfiguration();

            collection.AddSingleton<IConfiguration>(configuration);

            collection.AddSingleton<IPlayRepository, PlayRepository>();
            
            collection.AddSingleton<IPlayService, PlayService>();
            
            IocContainer.Init(collection);

        }
        private static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
       
    }
}