using System.Collections.Generic;
using System.Linq;
using ServiceRegister.Store.CodeFirst.Model;

namespace ServiceRegister.Store.CodeFirst.Querying
{
    internal class PostalPostOfficeBoxAddressQuery
    {
        private readonly ICollection<Address> addresses;

        public PostalPostOfficeBoxAddressQuery(ICollection<Address> addresses)
        {
            this.addresses = addresses;
        }

        public Address Execute()
        {
            return addresses == null ? null : addresses.SingleOrDefault(address => !string.IsNullOrWhiteSpace(address.PostOfficeBox));
        }
    }
}