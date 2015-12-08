"use strict";

module Affecto.Login
{
    export class AuthorizationInterceptorService
    {
        public static $inject = ["$injector", "requestedRouteService", "loginRoute"];

        private static httpUnauthorizedCode: number = 401;

        private qService: any;
        private locationService: any;
        private authenticationService: any;

        constructor(private $injector: angular.auto.IInjectorService, private requestedRouteService: RequestedRouteService, private loginRoute: string)
        {
            this.authenticationService = null;
        }

        public request = (config: angular.IRequestConfig): angular.IRequestConfig =>
        {
            if (this.qService == null)
            {
                this.qService = this.$injector.get("$q");
            }
            if (this.authenticationService == null)
            {
                this.authenticationService = this.$injector.get("authenticationService");
            }

            var accessToken: string = this.authenticationService.getAccessToken();
            config.headers = config.headers || {};

            if (accessToken != null)
            {
                config.headers.Authorization = "Bearer " + accessToken;
            }

            return config;
        }

        public responseError = (rejection: angular.IHttpPromiseCallbackArg<any>): angular.IPromise<void> =>
        {
            if (rejection.status === AuthorizationInterceptorService.httpUnauthorizedCode)
            {
                if (this.locationService == null)
                {
                    this.locationService = this.$injector.get("$location");
                }

                if (this.authenticationService != null)
                {
                    this.authenticationService.logOut();
                }

                var currentPath: string = this.locationService.path();
                if (currentPath !== this.loginRoute)
                {
                    this.requestedRouteService.route = currentPath;
                    this.authenticationService.redirectToLoginPage();
                }
            }

            return this.qService.reject(rejection);
        }
    }
}