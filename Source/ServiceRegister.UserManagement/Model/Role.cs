using System;
using ServiceRegister.Application.User;

namespace ServiceRegister.UserManagement.Model
{
    internal class Role : IRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}