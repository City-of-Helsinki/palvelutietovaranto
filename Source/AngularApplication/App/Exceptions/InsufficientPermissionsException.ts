"use strict";

module ServiceRegister
{
    export class InsufficientPermissionsException extends Affecto.Base.Exception
    {
        protected getExceptionName(): string
        {
            return "InsufficientPermissionsException";
        }
    }
}