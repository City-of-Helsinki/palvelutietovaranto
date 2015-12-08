"use strict";

module ServiceRegister
{
    export class ClassNotAvailableException extends Affecto.Base.Exception
    {
        protected getExceptionName(): string
        {
            return "ClassNotAvailableException";
        }
    }
}