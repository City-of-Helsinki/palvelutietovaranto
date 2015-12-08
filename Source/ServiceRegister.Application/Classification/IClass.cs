using System;

namespace ServiceRegister.Application.Classification
{
    public interface IClass
    {
        Guid Id { get; }
        string Name { get; }
    }
}
