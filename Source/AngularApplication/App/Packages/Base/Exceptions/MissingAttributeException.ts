"use strict";

module Affecto.Base
{
    export class MissingAttributeException extends Exception
    {
        constructor(message: string)
        {
            super(message);
        }

        protected getExceptionName(): string
        {
            return "Affecto.Base.Exceptions.MissingAttributeException";
        }
    }
}