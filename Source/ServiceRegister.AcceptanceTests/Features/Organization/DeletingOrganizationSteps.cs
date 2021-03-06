﻿using System;
using System.Collections.Generic;
using ServiceRegister.AcceptanceTests.Infrastructure;
using ServiceRegister.Common;
using TechTalk.SpecFlow;

namespace ServiceRegister.AcceptanceTests.Features.Organization
{
    [Binding]
    [Scope(Feature = "DeletingOrganization")]
    internal sealed class DeletingOrganizationSteps : StepDefinition
    {
        private const string LanguageCode = "fi";

        [Given(@"there is a fully filled organization '(.+)' with business id '(.+)'")]
        public void GivenThereIsAFullyFilledOrganizationWithBusinessId(string organizationName, string businessId)
        {
            Guid organizationId = OrganizationService.AddOrganization(businessId, "", "Yritys", null,
                new List<LocalizedText> { new LocalizedText(LanguageCode, organizationName) }, new List<LocalizedText> { new LocalizedText(LanguageCode, "Kiva kaupunki") });
            SetAllOrganizationData(organizationId);
        }

        [When(@"organization '(.+)' is deleted")]
        public void WhenOrganizationIsDeleted(string organizationName)
        {
            Guid organizationId = OrganizationHelper.GetOrganizationId(organizationName);
            Try(() => OrganizationService.RemoveOrganization(organizationId));
        }

        private void SetAllOrganizationData(Guid organizationId)
        {
            OrganizationService.SetOrganizationContactInformation(organizationId, "0100100", "ppm", "me@kaupunki.fi",
                new List<WebPage> { new WebPage("Index", "http://www.home.fi", "Kotisivu"), new WebPage("About", "http://www.home.fi/about", "Kotisivu") });
            OrganizationService.SetOrganizationVisitingAddress(organizationId, new List<LocalizedText> { new LocalizedText(LanguageCode, "Katu 1 A 12") }, "13245",
                new List<LocalizedText> { new LocalizedText(LanguageCode, "Kylä") }, new List<LocalizedText> { new LocalizedText(LanguageCode, "Kulmassa") });
            OrganizationService.SetOrganizationPostalAddresses(organizationId, false, new List<LocalizedText> { new LocalizedText(LanguageCode, "Katu 2 B 1") },
                "78945",
                new List<LocalizedText> { new LocalizedText(LanguageCode, "Kaupunki") }, "10", "23561",
                new List<LocalizedText> { new LocalizedText(LanguageCode, "Kaupunki") });
        }
    }
}