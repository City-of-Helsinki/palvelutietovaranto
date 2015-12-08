"use strict";

module ServiceRegister
{
    export class StreetAddress
    {
        constructor(public streetAddresses: Array<LocalizedText>, public postalCode: string, public postalDistricts: Array<LocalizedText>)
        {
        }
    }
}
 