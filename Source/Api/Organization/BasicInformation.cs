using System.Collections.Generic;
using ServiceRegister.Common;

namespace ServiceRegister.Api.Organization
{
    public class BasicInformation
    {
        public string BusinessId { get; set; }
        public IEnumerable<LocalizedText> Names { get; set; }
        public IEnumerable<LocalizedText> Descriptions { get; set; }
        public string Type { get; set; }
        public string MunicipalityCode { get; set; }
        public string Oid { get; set; }
    }
}