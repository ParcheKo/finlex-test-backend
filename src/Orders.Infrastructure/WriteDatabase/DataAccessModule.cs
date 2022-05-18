using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orders.Application.Configuration.Data;
using Orders.Domain.Orders;
using Orders.Domain.Persons;
using Orders.Domain.SeedWork;
using Orders.Infrastructure.Domain;
using Orders.Infrastructure.Domain.Orders;
using Orders.Infrastructure.Domain.Persons;
using Orders.Infrastructure.Helpers;

namespace Orders.Infrastructure.WriteDatabase;

public class DataAccessModule : Module
{
    private readonly DatabaseConfiguration _databaseConfiguration;
    private readonly string _databaseConnectionString;

    public DataAccessModule(DatabaseConfiguration databaseConfiguration)
    {
        _databaseConfiguration = databaseConfiguration;
        _databaseConnectionString = databaseConfiguration.ConnectionStrings.SqlServerConnectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SqlConnectionFactory>()
            .As<ISqlConnectionFactory>()
            .WithParameter(
                "connectionString",
                _databaseConnectionString
            )
            .InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        builder.RegisterType<OrderRepository>()
            .As<IOrderRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<PersonRepository>()
            .As<IPersonRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<StronglyTypedIdValueConverterSelector>()
            .As<IValueConverterSelector>()
            .SingleInstance();

        builder
            .Register(
                c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<OrdersContext>();
                    dbContextOptionsBuilder.UseSqlServer(
                            _databaseConnectionString,
                            b => b.MigrationsAssembly(typeof(OrdersContext).Assembly.GetName().Name)
                        )
                        .ConfigureDatabaseNamingConvention(_databaseConfiguration.DatabaseNamingConvention);
                    dbContextOptionsBuilder
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    return new OrdersContext(dbContextOptionsBuilder.Options);
                }
            )
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}