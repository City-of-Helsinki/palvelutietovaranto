using Affecto.Mapping;
using NSubstitute;
using ServiceRegister.Api.Service;
using ServiceRegister.Application.Service;

namespace ServiceRegister.Api.Tests.Service
{
    public abstract class ServiceControllerTests
    {
        protected MapperFactory mapperFactory;
        protected IMapper<IServiceListItem, ServiceListItem> serviceNameMapper;
        protected IMapper<IService, Api.Service.Service> serviceMapper;

        protected void SetupMappers()
        {
            mapperFactory = Substitute.For<MapperFactory>();
            serviceNameMapper = Substitute.For<IMapper<IServiceListItem, ServiceListItem>>();
            serviceMapper = Substitute.For<IMapper<IService, Api.Service.Service>>();
            mapperFactory.CreateServiceNameMapper().Returns(serviceNameMapper);
            mapperFactory.CreateServiceMapper().Returns(serviceMapper);
        }
    }
}
