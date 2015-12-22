// ReSharper disable PossibleMultipleEnumeration

using System;
using System.Collections.Generic;
using System.Linq;
using Affecto.Authentication.Claims;
using Affecto.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ServiceRegister.Application.User;
using ServiceRegister.Common.User;
using ServiceRegister.UserManagement.Mapping;
using ServiceRegister.UserManagement.Model;
using IdentityManagement = Affecto.IdentityManagement.Interfaces;

namespace ServiceRegister.UserManagement.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService sut;
        private IdentityManagement.IIdentityManagementService identityManagementService;
        private MapperFactory mapperFactory;
        private IAuthenticatedUserContext userContext;

        private static readonly Guid ExpectedRoleId = Guid.NewGuid();
        private static readonly Guid ExpectedOrganizationId = Guid.NewGuid();
        private static readonly string ExpectedEmailAddress = "foo@bar.com";
        private static readonly string ExpectedPassword = "PaSS";
        private static readonly string ExpectedLastName = "Clarkson";
        private static readonly string ExpectedFirstName = "Jeremy";
        private static readonly string ExpectedPhoneNumber = "5562423422-234";

        [TestInitialize]
        public void Setup()
        {
            identityManagementService = Substitute.For<IdentityManagement.IIdentityManagementService>();
            mapperFactory = Substitute.For<MapperFactory>();
            userContext = Substitute.For<IAuthenticatedUserContext>();
            sut = new UserService(identityManagementService, mapperFactory, userContext);

            var role = Substitute.For<IdentityManagement.Model.IRole>();
            role.Id.Returns(ExpectedRoleId);
            role.Name.Returns(Roles.Administrator);
            identityManagementService.GetRoles().Returns(new List<IdentityManagement.Model.IRole> { role });
        }

        [TestMethod]
        public void RolesAreReturned()
        {
            var returnedRoles = new List<IdentityManagement.Model.IRole>
            {
                Substitute.For<IdentityManagement.Model.IRole>(),
                Substitute.For<IdentityManagement.Model.IRole>()
            };

            var expectedRoles = new List<Role>
            {
                new Role { Id = Guid.NewGuid(), Name = "Admin" },
                new Role { Id = Guid.NewGuid(), Name = "Basic" }
            };

            var mapper = Substitute.For<IMapper<IdentityManagement.Model.IRole, Role>>();
            mapper.Map(returnedRoles[0]).Returns(expectedRoles[0]);
            mapper.Map(returnedRoles[1]).Returns(expectedRoles[1]);
            mapperFactory.CreateRoleMapper().Returns(mapper);

            identityManagementService.GetRoles().Returns(returnedRoles);

            IEnumerable<IRole> result = sut.GetRoles();

            Assert.AreEqual(2, result.Count());
            Assert.AreSame(expectedRoles[0], result.First());
            Assert.AreSame(expectedRoles[1], result.Last());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RoleIdCannotBeEmptyWhenAddingUser()
        {
            sut.AddUser(Guid.Empty, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OrganizationIdCannotBeEmptyWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, Guid.Empty, ExpectedEmailAddress, ExpectedPassword, ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmailAddressCannotBeNullWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, null, ExpectedPassword, ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmailAddressCannotBeEmptyWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, "", ExpectedPassword, ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmailAddressCannotBeWhitespaceWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, " ", ExpectedPassword, ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PasswordCannotBeNullWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, null, ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PasswordCannotBeEmptyWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, "", ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PasswordCannotBeWhitespaceWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, " ", ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LastNameCannotBeNullWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, null, ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LastNameCannotBeEmptyWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, "", ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LastNameCannotBeWhitespaceWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, " ", ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FirstNameCannotBeNullWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, ExpectedLastName, null, ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FirstNameCannotBeEmptyWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, ExpectedLastName, "", ExpectedPhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FirstNameCannotBeWhitespaceWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, ExpectedLastName, " ", ExpectedPhoneNumber);
        }

        [TestMethod]
        public void DisplayNameIsGeneratedWhenAddingUser()
        {
            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);

            identityManagementService.Received(1).CreateUser($"{ExpectedLastName} {ExpectedFirstName}",
                Arg.Any<IEnumerable<KeyValuePair<string, string>>>());
        }

        [TestMethod]
        public void CustomPropertiesAreSavedWhenAddingUser()
        {
            IEnumerable<KeyValuePair<string, string>> customProperties = null;
            identityManagementService
                .When(s => s.CreateUser(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>()))
                .Do(callInfo => customProperties = callInfo.Arg<IEnumerable<KeyValuePair<string, string>>>());

            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);

            identityManagementService.Received(1).CreateUser(Arg.Any<string>(),
                Arg.Any<IEnumerable<KeyValuePair<string, string>>>());
            
            Assert.IsNotNull(customProperties);
            Assert.AreEqual(5, customProperties.Count());
            Assert.IsNotNull(customProperties.SingleOrDefault(p => p.Key == CustomPropertyName.LastName.ToString() && p.Value == ExpectedLastName));
            Assert.IsNotNull(customProperties.SingleOrDefault(p => p.Key == CustomPropertyName.FirstName.ToString() && p.Value == ExpectedFirstName));
            Assert.IsNotNull(customProperties.SingleOrDefault(p => p.Key == CustomPropertyName.EmailAddress.ToString() && p.Value == ExpectedEmailAddress));
            Assert.IsNotNull(customProperties.SingleOrDefault(p => p.Key == CustomPropertyName.PhoneNumber.ToString() && p.Value == ExpectedPhoneNumber));
            Assert.IsNotNull(customProperties.SingleOrDefault(p => p.Key == CustomPropertyName.OrganizationId.ToString() && p.Value == ExpectedOrganizationId.ToString()));
        }

        [TestMethod]
        public void UsersRoleIsSetWhenAddingUser()
        {
            var expectedUser = Substitute.For<IdentityManagement.Model.IUserListItem>();
            expectedUser.Id.Returns(Guid.NewGuid());

            identityManagementService
                .CreateUser(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>())
                .Returns(expectedUser);

            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);

            identityManagementService.Received(1).AddUserRole(expectedUser.Id, ExpectedRoleId);
        }

        [TestMethod]
        public void UserIdIsReturnedWhenAddingUser()
        {
            var expectedUser = Substitute.For<IdentityManagement.Model.IUserListItem>();
            expectedUser.Id.Returns(Guid.NewGuid());

            identityManagementService
                .CreateUser(Arg.Any<string>(), Arg.Any<IEnumerable<KeyValuePair<string, string>>>())
                .Returns(expectedUser);

            Guid userId = sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);

            Assert.AreEqual(expectedUser.Id, userId);
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientPermissionsException))]
        public void AdministratorUserCannotBeAddedWithoutPermission()
        {
            userContext
                .When(u => u.CheckPermission(Permissions.Users.ManageAdministratorUsers))
                .Do(callInfo => { throw new InsufficientPermissionsException(Permissions.Users.ManageAdministratorUsers); });

            sut.AddUser(ExpectedRoleId, ExpectedOrganizationId, ExpectedEmailAddress, ExpectedPassword, ExpectedLastName, ExpectedFirstName, ExpectedPhoneNumber);
        }

        [TestMethod]
        public void UsersAreReturnedForUsersOrganization()
        {
            Guid organizationId = Guid.NewGuid();

            userContext.HasCustomProperty(CustomPropertyName.OrganizationId.ToString()).Returns(true);
            userContext.GetCustomPropertyValue(CustomPropertyName.OrganizationId.ToString()).Returns(organizationId.ToString("D"));
            userContext
                .When(u => u.CheckPermission(Permissions.Users.ViewAllUsers))
                .Do(callInfo => { throw new InsufficientPermissionsException(Permissions.Users.ViewAllUsers); });

            var returnedUsers = new List<IdentityManagement.Model.IUser>
            {
                Substitute.For<IdentityManagement.Model.IUser>(),
                Substitute.For<IdentityManagement.Model.IUser>()
            };

            var expectedUsers = new List<UserListItem>
            {
                new UserListItem { Id = Guid.NewGuid() },
                new UserListItem { Id = Guid.NewGuid() }
            };

            var mapper = Substitute.For<IMapper<IdentityManagement.Model.IUser, UserListItem>>();
            mapper.Map(returnedUsers[0]).Returns(expectedUsers[0]);
            mapper.Map(returnedUsers[1]).Returns(expectedUsers[1]);
            mapperFactory.CreateUserMapper().Returns(mapper);

            identityManagementService.GetUsers(CustomPropertyName.OrganizationId.ToString(), organizationId.ToString("D")).Returns(returnedUsers);

            IEnumerable<IUserListItem> result = sut.GetUsers(organizationId);

            Assert.AreEqual(2, result.Count());
            Assert.AreSame(expectedUsers[0], result.First());
            Assert.AreSame(expectedUsers[1], result.Last());
        }

        [TestMethod]
        public void UsersAreReturnedForOtherOrganization()
        {
            Guid organizationId = Guid.NewGuid();

            userContext.HasCustomProperty(CustomPropertyName.OrganizationId.ToString()).Returns(true);
            userContext.GetCustomPropertyValue(CustomPropertyName.OrganizationId.ToString()).Returns(Guid.NewGuid().ToString("D"));
            userContext
                .When(u => u.CheckPermission(Permissions.Users.ViewUserOrganizationUsers))
                .Do(callInfo => { throw new InsufficientPermissionsException(Permissions.Users.ViewUserOrganizationUsers); });

            var returnedUsers = new List<IdentityManagement.Model.IUser>
            {
                Substitute.For<IdentityManagement.Model.IUser>(),
                Substitute.For<IdentityManagement.Model.IUser>()
            };

            var expectedUsers = new List<UserListItem>
            {
                new UserListItem { Id = Guid.NewGuid() },
                new UserListItem { Id = Guid.NewGuid() }
            };

            var mapper = Substitute.For<IMapper<IdentityManagement.Model.IUser, UserListItem>>();
            mapper.Map(returnedUsers[0]).Returns(expectedUsers[0]);
            mapper.Map(returnedUsers[1]).Returns(expectedUsers[1]);
            mapperFactory.CreateUserMapper().Returns(mapper);

            identityManagementService.GetUsers(CustomPropertyName.OrganizationId.ToString(), organizationId.ToString("D")).Returns(returnedUsers);

            IEnumerable<IUserListItem> result = sut.GetUsers(organizationId);

            Assert.AreEqual(2, result.Count());
            Assert.AreSame(expectedUsers[0], result.First());
            Assert.AreSame(expectedUsers[1], result.Last());
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientPermissionsException))]
        public void NoUsersAreReturnedIfNoPermissions()
        {
            Guid organizationId = Guid.NewGuid();

            userContext.HasCustomProperty(CustomPropertyName.OrganizationId.ToString()).Returns(true);
            userContext.GetCustomPropertyValue(CustomPropertyName.OrganizationId.ToString()).Returns(Guid.NewGuid().ToString("D"));
            userContext
                .When(u => u.CheckPermission(Permissions.Users.ViewUserOrganizationUsers))
                .Do(callInfo => { throw new InsufficientPermissionsException(Permissions.Users.ViewUserOrganizationUsers); });
            userContext
                .When(u => u.CheckPermission(Permissions.Users.ViewAllUsers))
                .Do(callInfo => { throw new InsufficientPermissionsException(Permissions.Users.ViewAllUsers); });

            sut.GetUsers(organizationId);
        }

        [TestMethod]
        public void NullPasswordIsNotValid()
        {
            bool isValid = sut.ValidatePasswordStrength(null);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void EmptyPasswordIsNotValid()
        {
            bool isValid = sut.ValidatePasswordStrength(string.Empty);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void TooShortPasswordIsNotValid()
        {
            bool isValid = sut.ValidatePasswordStrength("aB1&");
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PasswordWithoutEnoughCharacterClassesIsNotValid()
        {
            bool isValid = sut.ValidatePasswordStrength("aaaBBBcccDDD");
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PasswordIsValid()
        {
            bool isValid = sut.ValidatePasswordStrength("aaaBBB333&#_");
            Assert.IsTrue(isValid);
        }
    }
}