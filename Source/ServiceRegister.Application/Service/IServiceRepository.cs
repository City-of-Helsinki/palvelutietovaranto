using System;
using System.Collections.Generic;

namespace ServiceRegister.Application.Service
{
    public interface IServiceRepository
    {
        void AddService(Guid organizationId, IService service);
        void SaveChanges();
        IService GetService(Guid organizationId, Guid serviceId);
        IEnumerable<IServiceListItem> GetServices(Guid organizationId);
        void UpdateServiceBasicInformation(Guid organizationId, Guid serviceId, IBasicInformation information);
        void RemoveService(Guid organizationId, Guid serviceId);
    }
}
