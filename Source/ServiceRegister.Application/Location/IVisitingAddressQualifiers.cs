using System.Collections.Generic;
using ServiceRegister.Common;

namespace ServiceRegister.Application.Location
{
    public interface IVisitingAddressQualifiers
    {
        IEnumerable<LocalizedText> VisitingAddressQualifiers { get; }
        string GetVisitingAddressQualifier(string languageCode);
    }
}