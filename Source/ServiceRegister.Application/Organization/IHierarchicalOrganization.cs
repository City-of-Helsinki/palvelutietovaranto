using System;
using System.Collections.Generic;

namespace ServiceRegister.Application.Organization
{
    public interface IHierarchicalOrganization : IOrganizationName, IHierarchical
    {
        IEnumerable<IHierarchicalOrganization> SubOrganizations { get; }
    }
}