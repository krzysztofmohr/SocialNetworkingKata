using System.Reflection;
using Autofac;
using SocialNetworking.Domain.Services;
using static System.Console;

namespace SocialNetworking.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var socialNetwork = BootstrapSocialNetwork();

            WriteLine("Start by entering command (press 'q' to quit): ");
            while (true)
            {                
                var commandText = ReadLine();
                if (commandText == "q") return;
                socialNetwork.EnterCommand(commandText);                
            }
        }

        private static ISocialNetworkService BootstrapSocialNetwork()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(SocialNetworkService)))
                .AsImplementedInterfaces();

            return builder
                .Build().Resolve<ISocialNetworkService>();
        }
    }
}
