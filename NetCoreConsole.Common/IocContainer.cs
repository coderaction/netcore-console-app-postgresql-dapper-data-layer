using Microsoft.Extensions.DependencyInjection;

namespace NetCoreConsole.Common
{
    public static class IocContainer
    {
        private static IServiceCollection _services;
        private static ServiceProvider _provider;

        public static void Init(IServiceCollection services)
        {
            _services = services;
            
            _provider = _services.BuildServiceProvider();
        }

        public static TInstance Resolve<TInstance>()
        {
            return _provider.GetService<TInstance>();
        }
    }
}