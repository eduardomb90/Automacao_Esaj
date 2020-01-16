using Autofac;
using RoboEsaj.Domain.Utilities;


namespace RoboEsaj.Domain.Helpers
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ClasseDeNavegacao>().As<IClasseDeNavegacao>();

            return builder.Build();
        }
    }
}
