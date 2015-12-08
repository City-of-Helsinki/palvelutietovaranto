using System;
using System.Collections.Generic;
using ServiceRegister.Application.Localization;
using ServiceRegister.Common;

namespace ServiceRegister.Application.Organization
{
    internal class OrganizationName : IOrganizationName
    {
        protected readonly MandatoryLocalizedSingleTexts names;

        public OrganizationName(Guid id, IEnumerable<LocalizedText> names)
        {
            this.names = new MandatoryLocalizedSingleTexts(names);
            Id = id;
        }

        public Guid Id { get; private set; }

        public LocalizedSingleTexts Names
        {
            get { return names; }
        }
    }
}
