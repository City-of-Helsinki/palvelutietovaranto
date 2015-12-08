using System.Collections.Generic;
using ServiceRegister.Common;

namespace ServiceRegister.Api.Location
{
    public class VisitingAddress
    {
        public string PostalCode { get; set; }
        public IEnumerable<LocalizedText> StreetAddresses { get; set; }
        public IEnumerable<LocalizedText> PostalDistricts { get; set; }
        public IEnumerable<LocalizedText> Qualifiers { get; set; }
    }
}