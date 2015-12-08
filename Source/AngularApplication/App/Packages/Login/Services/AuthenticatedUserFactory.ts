"use strict";

module Affecto.Login
{
    export interface IAuthenticatedUserFactory
    {
        createUser(jsonData: any): AuthenticatedUser;
    }

    export class AuthenticatedUserFactory implements IAuthenticatedUserFactory
    {
        public createUser(jsonData: any): AuthenticatedUser
        {
            return new AuthenticatedUser(jsonData.name, jsonData.accountName, jsonData.roles, jsonData.permissions, jsonData.customProperties);
        }
    }
}