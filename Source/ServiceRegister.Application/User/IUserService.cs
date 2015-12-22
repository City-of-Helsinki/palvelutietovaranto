﻿using System;
using System.Collections.Generic;

namespace ServiceRegister.Application.User
{
    public interface IUserService
    {
        Guid AddUser(Guid roleId, Guid organizationId, string emailAddress, string password, string lastName, string firstName, string phoneNumber);
        IEnumerable<IRole> GetRoles();
        IEnumerable<IUserListItem> GetUsers(Guid organizationId);
        bool IsExistingUser(string emailAddress);
        bool ValidatePasswordStrength(string password);
    }
}