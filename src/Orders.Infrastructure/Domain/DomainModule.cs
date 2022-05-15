using Autofac;

namespace Orders.Infrastructure.Domain;

public class DomainModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // builder.RegisterType<PersonEmailUniquenessChecker>()
        //     .As<IPersonEmailUniquenessChecker>()
        //     .InstancePerLifetimeScope();
        //
    }
}