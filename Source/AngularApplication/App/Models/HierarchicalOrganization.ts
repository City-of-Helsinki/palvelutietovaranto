"use strict";

module ServiceRegister
{
    export class HierarchicalOrganization extends OrganizationName implements Affecto.Base.IModel
    {
        public name: string;

        constructor(id: string, names: Array<LocalizedText>, public subOrganizations: Array<HierarchicalOrganization>)
        {
            super(id, names);
        }
    }
}  