using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Affecto.Authentication.Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceRegister.Common;
using ServiceRegister.Common.User;
using AuthenticatedUserFactory = ServiceRegister.Api.AuthenticatedUser.AuthenticatedUserFactory;

namespace ServiceRegister.Api.Tests.AuthenticatedUser
{
    [TestClass]
    public class AuthenticaterUserFactoryTests
    {
        private AuthenticatedUserFactory sut;

        private static readonly Guid ExpectedId = Guid.NewGuid();
        private static readonly string ExpectedName = "JohnDoe";
        private static readonly string ExpectedAccountName = "domain\\JohnDoe";
        private static readonly Guid ExpectedOrganizationId = Guid.NewGuid();

        private static readonly List<Claim> Claims = new List<Claim>
        {
            new Claim(ClaimType.Id, ExpectedId.ToString("D")),
            new Claim(ClaimType.Name, ExpectedName),
            new Claim(ClaimType.AccountName, ExpectedAccountName),
            new Claim(ClaimTypePrefix.CustomProperty + CustomPropertyName.OrganizationId, ExpectedOrganizationId.ToString("D"))
        };

        [TestInitialize]
        public void Setup()
        {
            sut = new AuthenticatedUserFactory(Claims);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OrganizationIdMustBeProvided()
        {
            IEnumerable<Claim> claims = Claims.Where(c => !c.Type.StartsWith(ClaimTypePrefix.CustomProperty));
            sut = new AuthenticatedUserFactory(claims);
            sut.Create();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OnlyOneOrganizationIdCanBeProvided()
        {
            IEnumerable<Claim> claims = new List<Claim>(Claims)
            {
                new Claim(ClaimTypePrefix.CustomProperty + CustomPropertyName.OrganizationId, ExpectedOrganizationId.ToString("D"))
            };
            sut = new AuthenticatedUserFactory(claims);
            sut.Create();
        }

        [TestMethod]
        public void OrganizationIdIsSet()
        {
            Api.AuthenticatedUser.AuthenticatedUser user = sut.Create();
            Assert.AreEqual(ExpectedOrganizationId, user.OrganizationId);
        }
    }
}