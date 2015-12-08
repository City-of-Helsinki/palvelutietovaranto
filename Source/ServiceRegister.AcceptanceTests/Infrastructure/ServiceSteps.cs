using System;
using System.Collections.Generic;
using ServiceRegister.Common;
using ServiceRegister.Tests.Infrastructure;
using TechTalk.SpecFlow;

namespace ServiceRegister.AcceptanceTests.Infrastructure
{
    [Binding]
    internal class ServiceSteps : StepDefinition
    {
        [Given(@"there is a service")]
        public void GivenThereIsAService()
        {
            Guid serviceId = ServiceService.AddService(CurrentScenarioContext.OrganizationId, new List<LocalizedText> { new LocalizedText("fi", "palvelu")}, null,
                new List<LocalizedText> { new LocalizedText("fi", "palvelun kuvaus") }, new List<LocalizedText> { new LocalizedText("fi", "kuvaus") },
                new List<LocalizedText> { new LocalizedText("fi", "ohjeet") }, new List<string> { "fi" },  new List<LocalizedText> { new LocalizedText("fi", "vaatimukset") });
            CurrentScenarioContext.ServiceId = serviceId;
        }
    }
}
