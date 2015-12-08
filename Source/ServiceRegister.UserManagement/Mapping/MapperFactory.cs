using Affecto.Mapping;
using Affecto.IdentityManagement.Interfaces.Model;
using ServiceRegister.UserManagement.Model;

namespace ServiceRegister.UserManagement.Mapping
{
    internal class MapperFactory
    {
        public virtual IMapper<IRole, Role> CreateRoleMapper()
        {
            return new RoleMapper();
        }

        public virtual IMapper<IUser, UserListItem> CreateUserMapper()
        {
            return new UserListItemMapper(CreateRoleMapper());
        }
    }
}