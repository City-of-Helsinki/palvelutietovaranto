using Affecto.Mapping;
using ServiceRegister.Api.Classification;
using ServiceRegister.Api.Organization;
using ServiceRegister.Api.Service;
using ServiceRegister.Api.Settings;
using ServiceRegister.Api.User;
using ServiceRegister.Api.Validation;
using ServiceRegister.Application.Classification;
using ServiceRegister.Application.Organization;
using ServiceRegister.Application.Service;
using ServiceRegister.Application.Settings;
using ServiceRegister.Application.User;
using ServiceRegister.Application.Validation;
using ServiceRegister.Common;

namespace ServiceRegister.Api
{
    public class MapperFactory
    {
        public virtual IMapper<IHierarchicalOrganization, HierarchicalOrganization> CreateHierarchicalOrganizationMapper()
        {
            return new HierarchicalOrganizationMapper();
        }

        public virtual IMapper<IOrganizationName, OrganizationName> CreateOrganizationNameMapper()
        {
            return new OrganizationNameMapper();
        }

        public virtual IMapper<IBusinessIdentifierValidationResult, BusinessIdentifierValidationResult> CreateBusinessIdentifierValidationResultMapper()
        {
            return new BusinessIdentifierValidationResultMapper();
        }

        public virtual IMapper<IOrganization, Organization.Organization> CreateOrganizationMapper()
        {
            return new OrganizationMapper();
        }

        public virtual IMapper<IServiceListItem, ServiceListItem> CreateServiceNameMapper()
        {
            return new ServiceListItemMapper();
        }

        public virtual IMapper<IService, Service.Service> CreateServiceMapper()
        {
            return new ServiceMapper();
        }

        public virtual IMapper<IRole, Role> CreateRoleMapper()
        {
            return new RoleMapper();
        }

        public virtual IMapper<ILanguage, Language> CreateLanguageMapper()
        {
            return new LanguageMapper();
        }

        public virtual IMapper<IHierarchicalClass, HierarchicalClass> CreateHierarchicalClassMapper()
        {
            return new HierarchicalClassMapper();
        }

        public virtual IMapper<IUserListItem, UserListItem> CreateUserListItemMapper()
        {
            return new UserListItemMapper(CreateRoleMapper());
        }

        public virtual IMapper<IClass, Class> CreateClassMapper()
        {
            return new ClassMapper();
        }
    }
}