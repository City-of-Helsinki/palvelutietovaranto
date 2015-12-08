using Affecto.Mapping.AutoMapper;
using AutoMapper;
using ServiceRegister.Application.Organization;

namespace ServiceRegister.Api.Organization
{
    internal class OrganizationNameMapper : OneWayMapper<IOrganizationName, OrganizationName>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IOrganizationName, OrganizationName>();
        }
    }
}