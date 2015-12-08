"use strict";

module ServiceRegister
{
    export class UserListItem implements Affecto.Base.IModel
    {
        constructor(public id: string, public role: UserRole, public organization: OrganizationName, public emailAddress: string, public lastName: string, public firstName: string)
        {
        }
    }
}
 