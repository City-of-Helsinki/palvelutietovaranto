using System;
using System.Collections.Generic;
using ServiceRegister.Common;

namespace ServiceRegister.Application.Service
{
    public interface IServiceListItem
    {
        Guid Id { get; }
        IEnumerable<LocalizedText> Names { get; }
        string ServiceClasses { get; }
        string OntologyTerms { get; }
    }
}
