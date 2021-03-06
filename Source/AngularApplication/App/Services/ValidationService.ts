﻿"use strict";

module ServiceRegister
{
    export class ValidationService
    {
        public static $inject = ["$http", "apiBaseUrl"];

        constructor(private $http: angular.IHttpService, private apiBaseUrl: string)
        {
        }

        public validateBusinessId(businessId: string, organizationId: string, allowDuplicates: boolean): angular.IPromise<BusinessIdentifierValidationResult>
        {
            return this.$http.post(this.apiBaseUrl + "serviceregister/businessid", this.createBusinessIdValidationObject(businessId, organizationId, allowDuplicates))
                .then((response: angular.IHttpPromiseCallbackArg<any>): BusinessIdentifierValidationResult =>
                {
                    return new BusinessIdentifierValidationResult(response.data.isValid, response.data.reasonForInvalidity);
                });
        }

        public validatePhoneNumber(phoneNumber: string): angular.IPromise<boolean>
        {
            return this.$http.post(this.apiBaseUrl + "serviceregister/phonenumber", "\"" + phoneNumber + "\"")
                .then((response: angular.IHttpPromiseCallbackArg<any>): boolean =>
                {
                    return response.data;
                });
        }

        public validateEmailAddress(emailAddress: string): angular.IPromise<boolean>
        {
            return this.$http.post(this.apiBaseUrl + "serviceregister/emailaddress", "\"" + emailAddress + "\"")
                .then((response: angular.IHttpPromiseCallbackArg<any>): boolean =>
                {
                    return response.data;
                });
        }

        public validateWebAddress(webAddress: string): angular.IPromise<boolean>
        {
            return this.$http.post(this.apiBaseUrl + "serviceregister/webaddress", "\"" + webAddress + "\"")
                .then((response: angular.IHttpPromiseCallbackArg<any>): boolean =>
                {
                    return response.data;
                });
        }

        public validatePostalCode(postalCode: string): angular.IPromise<boolean>
        {
            return this.$http.post(this.apiBaseUrl + "serviceregister/postalcode", "\"" + postalCode + "\"")
                .then((response: angular.IHttpPromiseCallbackArg<any>): boolean =>
                {
                    return response.data;
                });
        }

        public validatePostOfficeBoxPostalCode(postalCode: string): angular.IPromise<boolean>
        {
            return this.$http.post(this.apiBaseUrl + "serviceregister/postofficeboxpostalcode", "\"" + postalCode + "\"")
                .then((response: angular.IHttpPromiseCallbackArg<any>): boolean =>
                {
                    return response.data;
                });
        }

        private createBusinessIdValidationObject(businessId: string, organizationId: string, allowDuplicates: boolean): any
        {
            return {
                businessId: businessId,
                organizationId: organizationId,
                allowDuplicates: allowDuplicates
            }
        }
    }
}