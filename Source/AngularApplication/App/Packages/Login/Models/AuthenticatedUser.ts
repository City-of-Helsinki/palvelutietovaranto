"use strict";

module Affecto.Login
{
    export class AuthenticatedUser
    {
        constructor(public name: string, public accountName: string, public roles: Array<string>, public permissions: Array<string>, public customProperties: Array<CustomProperty>)
        {
        }

        public hasPermission(permission: string): boolean
        {
            if (this.permissions == null)
            {
                return false;
            }
            return this.permissions.indexOf(permission) >= 0;
        }
    }
}