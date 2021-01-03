using System;
using NetCoreConsole.Common;
using NetCoreConsole.Service.Core;

namespace ConsoleApplication
{
    static class Program
    {
        private static IPlayService _playService;
        
        static void Main(string[] args)
        {
            DependencyRegistrar.RegisterDependencies();
            
            _playService = IocContainer.Resolve<IPlayService>();
            
            DateTime fileDate = new DateTime();
            var notExistsList = _playService.GetData(fileDate.ToString("yyyy-MM-dd")).Result;
            
        }
    }
}