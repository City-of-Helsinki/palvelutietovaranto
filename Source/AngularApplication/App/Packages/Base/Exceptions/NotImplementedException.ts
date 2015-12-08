"use strict";

module Affecto.Base
{
    export class NotImplementedException extends Exception
    {
        constructor(message: string)
        {
            super(message);
        }

        protected getExceptionName(): string
        {
            return "Affecto.Base.Exceptions.NotImplementedException";
        }
    }
}