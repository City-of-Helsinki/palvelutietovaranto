using System;
using System.Collections.Generic;
using ServiceRegister.Common;

namespace ServiceRegister.Api.Service
{
    public class ServiceListItem
    {
        public Guid Id { get; set; }
        public IEnumerable<LocalizedText> Names { get; set; }
        public string ServiceClasses { get; set; }
        public string OntologyTerms { get; set; }
    }
}