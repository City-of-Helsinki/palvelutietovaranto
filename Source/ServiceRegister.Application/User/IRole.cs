using System;

namespace ServiceRegister.Application.User
{
    public interface IRole
    {
        Guid Id { get; }
        string Name { get; }
    }
}