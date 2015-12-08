"use strict";

module ServiceRegister {
    export interface IUserRoute extends angular.route.IRouteParamsService {
        id: string;
        organizationId: string;
    }
} 