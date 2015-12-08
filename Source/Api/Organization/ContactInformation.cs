using System.Collections.Generic;
using ServiceRegister.Common;

namespace ServiceRegister.Api.Organization
{
    public class ContactInformation
    {
        public string PhoneNumber { get; set; }
        public string PhoneCallFee { get; set; }
        public string EmailAddress { get; set; }
        public IEnumerable<WebPage> WebPages { get; set; }
    }
}