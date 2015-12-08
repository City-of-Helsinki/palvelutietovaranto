using System;
using System.Collections.Generic;
using ServiceRegister.Common;

namespace ServiceRegister.Api.Organization
{
    public class OrganizationName
    {
        public Guid Id { get; set; }
        public IEnumerable<LocalizedText> Names { get; set; }
    }
}