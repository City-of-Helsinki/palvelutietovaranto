// ReSharper disable ObjectCreationAsStatement

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceRegister.Api.Tests.AuthenticatedUser
{
    [TestClass]
    public class AuthenticaterUserTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OrganizationIdCannotBeEmpty()
        {
            new Api.AuthenticatedUser.AuthenticatedUser(Guid.NewGuid(), "name", "accoutName", Guid.Empty);
        }

        [TestMethod]
        public void OrganizationIdIsSet()
        {
            Guid organizationid = Guid.NewGuid();
            var sut = new Api.AuthenticatedUser.AuthenticatedUser(Guid.NewGuid(), "name", "accoutName", organizationid);

            Assert.AreEqual(organizationid, sut.OrganizationId);
        }
    }
}