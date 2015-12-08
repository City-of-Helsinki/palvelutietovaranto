"use strict";

module ServiceRegister
{
    export interface IOrganizationRoute extends angular.route.IRouteParamsService
    {
        organizationId: string;
        parentOrganizationId: string;
    }
}