using Affecto.Mapping.AutoMapper;
using Affecto.IdentityManagement.Interfaces.Model;
using AutoMapper;
using ServiceRegister.UserManagement.Model;

namespace ServiceRegister.UserManagement.Mapping
{
    internal class RoleMapper : OneWayMapper<IRole, Role>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IRole, Role>();
        }
    }
}