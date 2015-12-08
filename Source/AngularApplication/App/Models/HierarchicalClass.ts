"use strict";

module ServiceRegister
{
    export class HierarchicalClass implements Affecto.Base.IModel
    {
        constructor(public id: string, public name: string, public children: Array<HierarchicalClass>)
        {
        }
    }
}   