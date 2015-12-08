using System;
using Affecto.IdentityManagement.Commanding;
using ServiceRegister.Application.User;

namespace ServiceRegister.UserManagement
{
    public class UserManagementTestEnvironment
    {
        private static readonly Guid AdministratorRoleId = Guid.Parse("B5A20242-A695-4E24-9173-88AF3A90D2E9");

        private readonly Lazy<IDbRepository> repository;
        private readonly Lazy<IUserService> userService;

        public UserManagementTestEnvironment(Lazy<IDbRepository> repository, Lazy<IUserService> userService)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }
            if (userService == null)
            {
                throw new ArgumentNullException("userService");
            }

            this.repository = repository;
            this.userService = userService;
        }

        public Guid AddTestUser(Guid organizationId, string emailAddress, string password, string lastName, string firstName)
        {
            return userService.Value.AddUser(AdministratorRoleId, organizationId, emailAddress, password, lastName, firstName, null);
        }

        public void RemoveAllUsers()
        {
            repository.Value.RemoveUsers();
            repository.Value.SaveChanges();
        }
    }
}