"use strict";

module Affecto.Base
{
    export class Exception implements Error
    {
        public stack: string;

        constructor(public message: string)
        {
            this.stack = (<any>new Error()).stack;
        }

        public get name(): string
        {
            return this.getExceptionName();
        }

        public toString(): string
        {
            return this.name + ": " + this.message;
        }

        protected getExceptionName(): string
        {
            throw new Error("Exception name not implemented.");
        }
    }
}