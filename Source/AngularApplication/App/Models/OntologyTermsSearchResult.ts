"use strict";

module ServiceRegister
{
    export class OntologyTermsSearchResult
    {
        constructor(public ontologyTerms: Array<Class>, public searchText: string)
        {
        }
    }
}   