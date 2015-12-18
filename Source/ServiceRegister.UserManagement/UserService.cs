using System;
using System.Collections.Generic;
using System.Linq;
using Affecto.Authentication.Claims;
using Affecto.Mapping;
using ServiceRegister.Application.User;
using ServiceRegister.Common.User;
using ServiceRegister.UserManagement.Mapping;
using IdentityManagement = Affecto.IdentityManagement.Interfaces;

namespace ServiceRegister.UserManagement
{
    internal class UserService : IUserService
    {
        private readonly IdentityManagement.IIdentityManagementService identityManagementService;
        private readonly MapperFactory mapperFactory;
        private readonly IAuthenticatedUserContext userContext;

        public UserService(IdentityManagement.IIdentityManagementService identityManagementService, MapperFactory mapperFactory,
            IAuthenticatedUserContext userContext)
        {
            if (identityManagementService == null)
            {
                throw new ArgumentNullException("identityManagementService");
            }
            if (mapperFactory == null)
            {
                throw new ArgumentNullException("mapperFactory");
            }
            if (userContext == null)
            {
                throw new ArgumentNullException("userContext");
            }

            this.identityManagementService = identityManagementService;
            this.mapperFactory = mapperFactory;
            this.userContext = userContext;
        }

        public IEnumerable<IRole> GetRoles()
        {
            var roleMapper = mapperFactory.CreateRoleMapper();
            return roleMapper.Map(identityManagementService.GetRoles());
        }

        public bool IsExistingUser(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentException("Email address cannot be empty.", "emailAddress");
            }

            return identityManagementService.IsExistingUserAccount(emailAddress, IdentityManagement.Model.AccountType.Password);
        }

        public Guid AddUser(Guid roleId, Guid organizationId, string emailAddress, string password, string lastName, string firstName, string phoneNumber)
        {
            if (roleId == Guid.Empty)
            {
                throw new ArgumentException("User's role id cannot be empty.", "roleId");
            }
            if (organizationId == Guid.Empty)
            {
                throw new ArgumentException("User's organization id cannot be empty.", "organizationId");
            }
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentException("User's email address cannot be empty.", "emailAddress");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("User's password cannot be empty.", "password");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("User's last name cannot be empty.", "lastName");
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("User's first name cannot be empty.", "firstName");
            }

            CheckManageUsersPermissions(roleId);

            if (IsExistingUser(emailAddress))
            {
                throw new ExistingUserAccountException(string.Format("User account '{0}' already exists.", emailAddress));
            }

            string displayName = string.Format("{0} {1}", lastName, firstName);

            var customProperties = new CustomProperties
            {
                OrganizationId = organizationId,
                LastName = lastName,
                FirstName = firstName,
                EmailAddress = emailAddress,
                PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber
            };

            IdentityManagement.Model.IUserListItem user = identityManagementService.CreateUser(displayName, customProperties.ToKeyValuePairs());
            identityManagementService.AddUserAccount(user.Id, emailAddress, password);
            identityManagementService.AddUserRole(user.Id, roleId);

            return user.Id;
        }

        public IEnumerable<IUserListItem> GetUsers(Guid organizationId)
        {
            Guid userOrganizationId = userContext.GetUserOrganizationId();
            if (organizationId == userOrganizationId)
            {
                userContext.CheckPermission(Permissions.Users.ViewUserOrganizationUsers);
            }
            else
            {
                userContext.CheckPermission(Permissions.Users.ViewAllUsers);
            }

            string organizationIdString = OrganizationId.Convert(organizationId);
            IEnumerable<IdentityManagement.Model.IUser> users = identityManagementService.GetUsers(CustomPropertyName.OrganizationId.ToString(),
                organizationIdString);

            var mapper = mapperFactory.CreateUserMapper();
            return mapper.Map(users).ToList();
        }

        private void CheckManageUsersPermissions(Guid roleId)
        {
            IEnumerable<IdentityManagement.Model.IRole> roles = identityManagementService.GetRoles();
            IdentityManagement.Model.IRole newRole = roles.SingleOrDefault(r => r.Id == roleId);

            if (newRole == null)
            {
                throw new ArgumentException(string.Format("No roles found with id '{0}'.", roleId));
            }

            if (newRole.Name == Roles.Administrator)
            {
                userContext.CheckPermission(Permissions.Users.ManageAdministratorUsers);
            }
        }
    }
}