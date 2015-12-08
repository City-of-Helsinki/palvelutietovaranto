using System;
using System.Collections.Generic;
using System.Linq;
using ServiceRegister.Store.CodeFirst.Model;

namespace ServiceRegister.Store.CodeFirst.Querying
{
    internal class ActiveMainOrganizationsQuery
    {
        private readonly IQueryable<Organization> organizations;

        public ActiveMainOrganizationsQuery(IQueryable<Organization> organizations)
        {
            if (organizations == null)
            {
                throw new ArgumentNullException("organizations");
            }
            this.organizations = organizations;
        }

        public IEnumerable<Organization> Execute()
        {
            return organizations.Where(o => o.Active && o.ParentOrganizationId == null);
        }
    }
}
