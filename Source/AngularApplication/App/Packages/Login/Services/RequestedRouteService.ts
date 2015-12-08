"use strict";

module Affecto.Login
{
    export class RequestedRouteService
    {
        public static $inject = ["localStorageService", "requestedRouteUrlParameter"];

        private routeValue: string;

        constructor(private localStorageService: angular.local.storage.ILocalStorageService, private requestedRouteUrlParameter: string)
        {
            this.routeValue = null;
        }

        public get route(): string
        {
            if (this.routeValue == null)
            {
                this.routeValue = this.localStorageService.get<string>(this.requestedRouteUrlParameter);
            }
            return this.routeValue;
        }

        public set route(route: string)
        {
            this.routeValue = route;
            this.localStorageService.set(this.requestedRouteUrlParameter, route);
        }

        public removeRoute(): void
        {
            this.routeValue = null;
            this.localStorageService.remove(this.requestedRouteUrlParameter);
        }
    }
}