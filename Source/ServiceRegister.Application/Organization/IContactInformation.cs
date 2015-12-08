using System.Collections.Generic;
using ServiceRegister.Common;

namespace ServiceRegister.Application.Organization
{
    public interface IContactInformation
    {
        string PhoneNumber { get; }
        string PhoneCallFee { get; }
        string EmailAddress { get; }
        IEnumerable<WebPage> WebPages { get; }
    }
}
