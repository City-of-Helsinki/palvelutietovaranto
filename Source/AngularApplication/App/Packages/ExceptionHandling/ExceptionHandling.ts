"use strict";

var exceptionHandlingModule: angular.IModule = angular.module("Affecto.ExceptionHandling", []);

exceptionHandlingModule.config([
    "$httpProvider", ($httpProvider: angular.IHttpProvider) =>
    {
        $httpProvider.interceptors.push("exceptionInterceptorService");
    }
]);

Affecto.Registration.registerController(Affecto.ExceptionHandling.ErrorController, "Affecto.ExceptionHandling.ErrorController");
Affecto.Registration.registerService(Affecto.ExceptionHandling.ExceptionInterceptorService, "Affecto.ExceptionHandling.ExceptionInterceptorService");