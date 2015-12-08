"use strict";

module ServiceRegister
{
    export class BusinessIdentifierValidationResult
    {
        constructor(public isValid: boolean, public reasonForInvalidity: string)
        {
        }
    }
}