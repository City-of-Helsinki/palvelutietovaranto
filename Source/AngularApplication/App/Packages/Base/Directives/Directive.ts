"use strict";

module Affecto.Base
{
    export class Directive implements IDirective
    {
        public link: any;
        public restrict: string;

        constructor(restrictions: DirectiveRestriction, public templateUrl?: string, public scope?: any, public require?: any)
        {
            this.link = this.linkDirective.bind(this);
            this.setRestrictions(restrictions);
        }

        protected linkDirective($scope: angular.IScope, element: JQuery, attributes?: angular.IAttributes, controller?: any): any
        {
            throw new Base.NotImplementedException("Directive link function must be implemented.");
        }

        private setRestrictions(restrictions: DirectiveRestriction): void
        {
            this.restrict = "";
            if (this.isRestrictedFor(restrictions, DirectiveRestriction.Attribute))
            {
                this.restrict = this.restrict + "A";
            }
            if (this.isRestrictedFor(restrictions, DirectiveRestriction.Element))
            {
                this.restrict = this.restrict + "E";
            }
            if (this.isRestrictedFor(restrictions, DirectiveRestriction.Class))
            {
                this.restrict = this.restrict + "C";
            }
        }

        private isRestrictedFor(restrictions: DirectiveRestriction, searchedRestriction: DirectiveRestriction): boolean
        {
            return (restrictions & searchedRestriction) === searchedRestriction;
        }
    }
}