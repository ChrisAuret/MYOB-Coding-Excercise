using Autofac;
using myob.domain;
using myob.domain.Interfaces;

namespace myob
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<DataImporter>().As<IDataImporter>();
            builder.RegisterType<PayslipGenerator>().As<IPayslipGenerator>();
            builder.RegisterType<PayCalculator>().As<IPayCalculator>();
            builder.RegisterType<TaxTable>().As<ITaxTable>();

            return builder.Build();
        }
    }
}