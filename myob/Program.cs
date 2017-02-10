using System;
using Autofac;

namespace myob
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

            Console.WriteLine("\r\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}