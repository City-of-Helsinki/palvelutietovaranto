"use strict";

module ServiceRegister
{
    export class OrganizationIdNotFoundException extends Affecto.Base.Exception
    {
        protected getExceptionName(): string
        {
            return "OrganizationIdNotFoundException";
        }
    }
}