using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Tests
{
    public static class Utility
    {
        public static IServiceProvider Provider()
        {
            var services = new ServiceCollection()
             .AddSingleton<ISimulator>(new Simulator())
             .AddSingleton<IRobot>(new Service.Implementations.Robot())
             .AddTransient<Invoker>();

            return services.BuildServiceProvider();
        }

        public static T GetRequiredService<T>()
        {

            var provider = Provider();
            return provider.GetRequiredService<T>();
        }
    }
}
