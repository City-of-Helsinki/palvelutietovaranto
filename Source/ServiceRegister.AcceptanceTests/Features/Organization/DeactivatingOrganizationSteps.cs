using System;
using System.Linq;
using ServiceRegister.AcceptanceTests.Infrastructure;
using TechTalk.SpecFlow;

namespace ServiceRegister.AcceptanceTests.Features.Organization
{
    [Binding]
    [Scope(Feature = "DeactivatingOrganization")]
    internal sealed class DeactivatingOrganizationSteps : StepDefinition
    {
        [When(@"organization '(.+)' is deactivated")]
        public void WhenOrganizationIsDeactivated(string organizationName)
        {
            Guid organizationId = OrganizationHelper.GetOrganizationId(organizationName);
            OrganizationService.DeactivateOrganization(organizationId);
        }
    }
}
