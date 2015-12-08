using System;
using System.Collections.Generic;
using System.Linq;
using ServiceRegister.Store.CodeFirst.Model;

namespace ServiceRegister.Store.CodeFirst.Querying
{
    internal class OrganizationServicesQuery
    {
        private readonly IQueryable<Service> services;

        public OrganizationServicesQuery(IQueryable<Service> services)
        {
            if (services == null)
            {
                throw new ArgumentNullException("services");
            }
            this.services = services;
        }

        public IEnumerable<Service> Execute(Guid organizationId)
        {
            return services.Where(o => o.OrganizationId.Equals(organizationId));
        }
    }
}

