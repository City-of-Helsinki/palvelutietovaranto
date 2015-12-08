using System.Collections.Generic;
using ServiceRegister.Common;

namespace ServiceRegister.Api.Location
{
    public class PostalAddresses
    {
        public IEnumerable<LocalizedText> StreetAddresses { get; set; }
        public string StreetAddressPostalCode { get; set; }
        public IEnumerable<LocalizedText> StreetAddressPostalDistricts { get; set; }

        public string PostOfficeBox { get; set; }
        public string PostOfficeBoxAddressPostalCode { get; set; }
        public IEnumerable<LocalizedText> PostOfficeBoxAddressPostalDistricts { get; set; }

        public bool UseVisitingAddress { get; set; }
    }
}