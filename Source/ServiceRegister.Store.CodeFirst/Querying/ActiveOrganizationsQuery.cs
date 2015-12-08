using System;
using System.Collections.Generic;
using System.Linq;
using ServiceRegister.Store.CodeFirst.Model;

namespace ServiceRegister.Store.CodeFirst.Querying
{
    internal class ActiveOrganizationsQuery
    {
        private readonly IQueryable<Organization> organizations;

        public ActiveOrganizationsQuery(IQueryable<Organization> organizations)
        {
            if (organizations == null)
            {
                throw new ArgumentNullException("organizations");
            }
            this.organizations = organizations;
        }

        public IEnumerable<Organization> Execute()
        {
            return organizations.Where(o => o.Active);
        }
    }
}
