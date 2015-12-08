using Affecto.Mapping.AutoMapper;
using AutoMapper;
using ServiceRegister.Application.Service;

namespace ServiceRegister.Api.Service
{
    internal class ServiceListItemMapper : OneWayMapper<IServiceListItem, ServiceListItem>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IServiceListItem, ServiceListItem>();
        }
    }
}