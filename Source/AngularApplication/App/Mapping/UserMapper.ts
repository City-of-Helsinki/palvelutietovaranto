"use strict";

module ServiceRegister
{
    export class UserMapper
    {
        public static map(data: any): User
        {
            return new User(data.emailAddress, data.password, data.lastName, data.firstName, data.phoneNumber, data.organizationId,
                data.roleId);
        }
    }
}