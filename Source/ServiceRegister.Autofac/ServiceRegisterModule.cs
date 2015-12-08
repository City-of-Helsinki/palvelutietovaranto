using Affecto.Patterns.Cqrs.Autofac;
using Autofac;
using ServiceRegister.Application.Classification;
using ServiceRegister.Application.Organization;
using ServiceRegister.Application.Service;
using ServiceRegister.Application.Settings;
using ServiceRegister.Application.Validation;
using ServiceRegister.Commanding.Service.CommandHandlers;
using ServiceRegister.Store.CodeFirst;

namespace ServiceRegister.Autofac
{
    public class ServiceRegisterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<CqrsModule>();
            RegisterServices(builder);
            RegisterRepositories(builder);
            RegisterCommandHandlers(builder);
        }

        private void RegisterCommandHandlers(ContainerBuilder builder)
        {
            builder.RegisterType<SetServiceClassificationHandler>().AsImplementedInterfaces();
        }

        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<OrganizationRepository>().As<IOrganizationRepository>();
            builder.RegisterType<SettingsRepository>().As<ISettingsRepository>();
            builder.RegisterType<ServiceRepository>().As<IServiceRepository>();
            builder.RegisterType<ClassificationRepository>().As<IClassificationRepository>();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<SettingsService>().As<ISettingsService>();
            builder.RegisterType<OrganizationService>().As<IOrganizationService>();
            builder.RegisterType<ValidationService>().As<IValidationService>();
            builder.RegisterType<ServiceService>().As<IServiceService>();
        }
    }
}