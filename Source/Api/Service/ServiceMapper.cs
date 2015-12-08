using Affecto.Mapping.AutoMapper;
using AutoMapper;
using ServiceRegister.Api.Classification;
using ServiceRegister.Application.Classification;
using ServiceRegister.Application.Service;

namespace ServiceRegister.Api.Service
{
    public class ServiceMapper : OneWayMapper<IService, Service>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IService, Service>();
            Mapper.CreateMap<IHierarchicalClass, HierarchicalClass>();
            Mapper.CreateMap<IClass, Class>();
        }
    }
}