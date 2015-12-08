"use strict";

module Affecto.ExceptionHandling
{
    export class ExceptionInterceptorService
    {
        // handledErrorCodes is application specific and needs to be injected in App.ts
        public static $inject = ["$q", "$location", "handledErrorCodes"];

        constructor(private $q: angular.IQService, private $location: angular.ILocationService, private handledErrorCodes: Array<string>)
        {
        }

        public responseError = (rejection: angular.IHttpPromiseCallbackArg<any>): angular.IPromise<void> =>
        {
            var rejectionData = rejection.data;
            if (this.isServerError(rejection.status) && !this.isHandledError(rejectionData))
            {
                if (rejectionData != null && rejectionData !== "")
                {
                    this.$location
                        .path(Routes.error)
                        .search(UrlParameters.errorCode, rejectionData);
                }
                else
                {
                    this.$location.path(Routes.error);
                }
            }
            return this.$q.reject(rejection);
        }

        private isServerError(code: number): boolean
        {
            return code.toString()[0] === "5";
        }

        private isHandledError(errorData: string): boolean
        {
            return this.handledErrorCodes.indexOf(errorData) !== -1;
        }
    }
}