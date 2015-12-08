using System;
using ServiceRegister.Application.Classification;

namespace ServiceRegister.Application.Service
{
    public interface IService : IBasicInformation, IClassification
    {
        Guid Id { get; }
        long NumericId { get; }
    }
}
