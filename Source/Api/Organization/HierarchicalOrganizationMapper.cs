using Affecto.Mapping.AutoMapper;
using AutoMapper;
using ServiceRegister.Application.Organization;

namespace ServiceRegister.Api.Organization
{
    internal class HierarchicalOrganizationMapper : OneWayMapper<IHierarchicalOrganization, HierarchicalOrganization>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IHierarchicalOrganization, HierarchicalOrganization>();
        }
    }
}