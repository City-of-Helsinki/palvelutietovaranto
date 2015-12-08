"use strict";

module ServiceRegister
{
    export interface IServiceRoute extends angular.route.IRouteParamsService
    {
        organizationId: string;
        serviceId: string;
    }
}