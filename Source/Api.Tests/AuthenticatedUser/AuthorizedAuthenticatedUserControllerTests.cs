using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ServiceRegister.Api.AuthenticatedUser;

namespace ServiceRegister.Api.Tests.AuthenticatedUser
{
    [TestClass]
    public class AuthorizedAuthenticatedUserControllerTests
    {
        private AuthorizedAuthenticatedUserController sut;
        private readonly IPrincipal principal = Substitute.For<IPrincipal>();

        public void Setup()
        {
            HttpActionContext context =
                new HttpActionContext(
                    new HttpControllerContext(new HttpRequestContext { Principal = principal }, new HttpRequestMessage(), new HttpControllerDescriptor(),
                        Substitute.For<IHttpController>()), new ReflectedHttpActionDescriptor());

            sut = new AuthorizedAuthenticatedUserController();
            sut.ActionContext = context;
        }

        [TestMethod]
        [ExpectedException(typeof(AuthenticatedUserNotResolvedException))]
        public void PrincipalCannotBeNull()
        {
            HttpActionContext context =
                new HttpActionContext(
                    new HttpControllerContext(new HttpRequestContext { Principal = null }, new HttpRequestMessage(), new HttpControllerDescriptor(),
                        Substitute.For<IHttpController>()), new ReflectedHttpActionDescriptor());

            sut = new AuthorizedAuthenticatedUserController();
            sut.ActionContext = context;
            sut.GetAuthenticatedUser();
        }

        [TestMethod]
        [ExpectedException(typeof(AuthenticatedUserNotResolvedException))]
        public void IdentityCannotBeNull()
        {
            principal.Identity.Returns((IIdentity) null);
            Setup();

            sut.GetAuthenticatedUser();
        }

        [TestMethod]
        [ExpectedException(typeof(AuthenticatedUserNotResolvedException))]
        public void IdentityMustBeClaimsIdentity()
        {
            principal.Identity.Returns(new GenericIdentity("Name"));
            Setup();

            sut.GetAuthenticatedUser();
        }

        [TestMethod]
        [ExpectedException(typeof(AuthenticatedUserNotResolvedException))]
        public void IdentityMustBeAuthenticated()
        {
            principal.Identity.Returns(new ClaimsIdentity((IEnumerable<Claim>) null, null));
            Setup();

            sut.GetAuthenticatedUser();
        }

        [TestMethod]
        [ExpectedException(typeof(AuthenticatedUserNotResolvedException))]
        public void CorrectExceptionIsThrownIfUnhandledException()
        {
            principal.Identity.Returns(new ClaimsIdentity(null, "Auth"));
            Setup();

            sut.GetAuthenticatedUser();
        }
    }
}