"use strict";

module ServiceRegister
{
    export class PostOfficeBoxAddress
    {
        constructor(public postOfficeBox: string, public postalCode: string, public postalDistricts: Array<LocalizedText>)
        {
        }
    }
}
  