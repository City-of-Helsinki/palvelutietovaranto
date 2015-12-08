using System;
using System.Configuration;
using System.Reflection;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ExceptionHandling;
using Affecto.Authentication.Claims;
using Affecto.Logging;
using Affecto.WebApi.Toolkit;
using Autofac;
using Autofac.Integration.WebApi;
using ServiceRegister.Api.AuthenticatedUser;
using ServiceRegister.Api.Authentication;
using ServiceRegister.Api.Classification;
using ServiceRegister.Api.Organization;
using ServiceRegister.Api.Service;
using ServiceRegister.Api.Settings;
using ServiceRegister.Api.User;
using ServiceRegister.Api.Validation;
using Module = Autofac.Module;

namespace ServiceRegister.Api
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            string requireHttpsSetting = ConfigurationManager.AppSettings["requireHttps"];
            bool requireHttps = (requireHttpsSetting != null && requireHttpsSetting.ToLower() == "true");

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            RegisterControllerFilters<OpenOrganizationController>(builder, requireHttps);
            RegisterControllerFilters<OpenServiceController>(builder, requireHttps);
            RegisterControllerFilters<OpenSettingsController>(builder, requireHttps);
            RegisterControllerFilters<OpenClassificationController>(builder, requireHttps);

            RegisterAuthorizedControllerFilters<AuthorizedValidationController>(builder, requireHttps);
            RegisterAuthorizedControllerFilters<AuthorizedAuthenticatedUserController>(builder, requireHttps);
            RegisterAuthorizedControllerFilters<AuthorizedOrganizationController>(builder, requireHttps);
            RegisterAuthorizedControllerFilters<AuthorizedServiceController>(builder, requireHttps);
            RegisterAuthorizedControllerFilters<AuthorizedUserController>(builder, requireHttps);

            builder.RegisterInstance(AuthenticationServerConfiguration.Settings).As<IAuthenticationServerConfiguration>();
            builder.RegisterType<RequestErrorLogger>().As<IExceptionLogger>();
            builder.RegisterType<MapperFactory>();

            builder.Register<IAuthenticatedUserContext>(b => new AuthenticatedUserContext(HttpContext.Current.User.Identity as ClaimsIdentity))
                .As<IAuthenticatedUserContext>()
                .InstancePerRequest();

            builder.Register(c => new Correlation(Guid.NewGuid().ToString(), "Service Register UI"))
                .As<ICorrelation>()
                .InstancePerRequest();
        }

        private static void RegisterControllerFilters<TController>(ContainerBuilder builder, bool requireHttps) where TController : IHttpController
        {
            builder.RegisterType<RequestExceptionFilter>()
                .AsWebApiExceptionFilterFor<TController>()
                .InstancePerRequest();

            builder.RegisterType<RequestLoggingFilter>()
                .AsWebApiActionFilterFor<TController>()
                .InstancePerRequest();

            if (requireHttps)
            {
                builder.RegisterType<RequireHttpsAttribute>()
                    .AsWebApiAuthorizationFilterFor<TController>()
                    .InstancePerRequest();
            }
        }

        private static void RegisterAuthorizedControllerFilters<TController>(ContainerBuilder builder, bool requireHttps) where TController : IHttpController
        {
            RegisterControllerFilters<TController>(builder, requireHttps);

            builder.RegisterType<AuthorizationLoggingFilter>()
                .AsWebApiAuthorizationFilterFor<TController>()
                .InstancePerRequest();
        }
    }
}