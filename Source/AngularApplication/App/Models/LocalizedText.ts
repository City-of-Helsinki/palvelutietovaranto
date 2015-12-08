"use strict";

module ServiceRegister
{
    export class LocalizedText implements Affecto.Base.IModel
    {
        constructor(public languageCode: string, public localizedValue: string)
        {
        }
    }
}
 