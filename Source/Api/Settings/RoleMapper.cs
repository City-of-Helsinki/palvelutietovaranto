using Affecto.Mapping.AutoMapper;
using AutoMapper;
using ServiceRegister.Application.User;

namespace ServiceRegister.Api.Settings
{
    public class RoleMapper : OneWayMapper<IRole, Role>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IRole, Role>();
        }
    }
}