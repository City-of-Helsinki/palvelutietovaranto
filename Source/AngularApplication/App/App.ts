"use strict";

var serviceRegisterApplication: angular.IModule = createApplication();

serviceRegisterApplication.config([
    "$httpProvider", ($httpProvider: angular.IHttpProvider) =>
    {
        //initialize common if not there
        if (!$httpProvider.defaults.headers.common)
        {
            $httpProvider.defaults.headers.common = { };
        }    
  
        //disable IE xhr request caching
        $httpProvider.defaults.cache = false;
        $httpProvider.defaults.headers.common["If-Modified-Since"] = "Mon, 26 Jul 1997 05:00:00 GMT";
        $httpProvider.defaults.headers.common["Cache-Control"] = "no-cache";
        $httpProvider.defaults.headers.common.Pragma = "no-cache";
    }
]);

serviceRegisterApplication.config(["$routeProvider", ($routeProvider: angular.route.IRouteProvider) =>
    {
        registerRoutes($routeProvider);
    }
]);


serviceRegisterApplication.config([
    "$translateProvider", ($translateProvider: angular.translate.ITranslateProvider) =>
    {
        $translateProvider
            .translations("fi", createTranslations())
            .preferredLanguage("fi");
    }
]);  

serviceRegisterApplication.config([
    "unsavedWarningsConfigProvider", (unsavedWarningsConfigProvider: any) =>
    {
        unsavedWarningsConfigProvider.navigateMessage = "UNSAVED_CHANGES_ON_PAGE_LEAVE";
        unsavedWarningsConfigProvider.reloadMessage = "UNSAVED_CHANGES_ON_PAGE_RELOAD";
    }
]);

serviceRegisterApplication.constant("handledErrorCodes", []);
initializeLoginConstants(ServiceRegister.UrlParameter.requestedRoute, ServiceRegister.Route.login);

serviceRegisterApplication.run([
    "$rootScope", "authenticationService", "requestedRouteService", "$location",
    ($rootScope: any, authenticationService: Affecto.Login.IAuthenticationService, requestedRouteService: Affecto.Login.RequestedRouteService,
        $location: angular.ILocationService) =>
    {
        $rootScope.EditedOrganizationSection = ServiceRegister.EditedOrganizationSection;
        $rootScope.$on("$routeChangeStart", (event: angular.IAngularEvent, next: any, current: any) =>
        {
            var currentPath: string = $location.path();
            if (currentPath !== Affecto.ExceptionHandling.Routes.error && currentPath !== ServiceRegister.Route.login && !authenticationService.isAuthenticated())
            {
                event.preventDefault();
                requestedRouteService.route = currentPath;
                authenticationService.redirectToLoginPage();
            }
        });
    }
]);

registerControllers();
registerServices();
registerDirectives();

function createApplication(): angular.IModule
{
    var applicationModules: Array<string> = new Array<string>();
    var referenceModules: Array<string> = [
        "ngRoute", "ngResource", "ngCookies", "pascalprecht.translate", "unsavedChanges", "localytics.directives", "Affecto.BusyIndication", "ServiceRegister.Settings",
        "Affecto.ExceptionHandling", "Affecto.Login", "treeControl"
    ];
    applicationModules.forEach(mod => referenceModules.push(mod));

    return angular.module("ServiceRegister", referenceModules);    
}

function registerRoutes($routeProvider: angular.route.IRouteProvider): void
{
    $routeProvider
        .when("/",
        {
            controller: "ServiceRegister.OrganizationTreeController",
            templateUrl: "App/Views/Index.html"
        })
        .when("/Organizations/:organizationId/NewService",
            {
            controller: "ServiceRegister.ServiceController",
            templateUrl: "App/Views/AddServiceWizard.html",
            resolve:
                {
                    editedSection: () =>
                    {
                        return ServiceRegister.EditedServiceSection.BasicInfromation;
                    }
                }
        })
        .when("/Organizations/:organizationId/Services",
        {
            controller: "ServiceRegister.ServiceSearchController",
            templateUrl: "App/Views/Services.html"
        })
        .when("/Organizations/:organizationId/Services/:serviceId",
        {
            controller: "ServiceRegister.ServiceController",
            templateUrl: "App/Views/Service.html"
        })
        .when(ServiceRegister.Route.login,
        {
            controller: "ServiceRegister.LoginController",
            templateUrl: "App/Views/Login.html"
        })
        .when("/Organizations/:organizationId/Users",
        {
            controller: "ServiceRegister.UserSearchController",
            templateUrl: "App/Views/Users.html"
        })
        .when("/Organizations/:organizationId/NewUser",
        {
            controller: "ServiceRegister.UserController",
            templateUrl: "App/Views/AddUser.html"
        })
        .when("/Users/:userId",
        {
            templateUrl: "App/Views/User.html"
        })
        .when("/Organizations",
        {
            controller: "ServiceRegister.OrganizationController",
            templateUrl: "App/Views/AddOrganizationWizard.html",
            resolve:
            {
                editedSection: () =>
                {
                    return ServiceRegister.EditedOrganizationSection.BasicInfromation;
                }
            }
})
        .when("/Organizations/:organizationId",
        {
            templateUrl: "App/Views/Organization.html"
        })
        .when("/Organizations/:parentOrganizationId/Organizations",
        {
            controller: "ServiceRegister.OrganizationController",
            templateUrl: "App/Views/AddOrganizationWizard.html",
            resolve:
            {
                editedSection: () =>
                {
                    return ServiceRegister.EditedOrganizationSection.BasicInfromation;
                }
            }
        })
        .when(Affecto.ExceptionHandling.Routes.error,
        {
            controller: "Affecto.ExceptionHandling.ErrorController",
            templateUrl: "App/Views/Error.html"
        })
        .otherwise(
        {
            redirectTo: "/"
        });
}

function registerControllers(): void
{
    Affecto.Registration.registerController(ServiceRegister.MainNavigationController, "ServiceRegister.MainNavigationController");
    Affecto.Registration.registerController(ServiceRegister.OrganizationController, "ServiceRegister.OrganizationController");
    Affecto.Registration.registerController(ServiceRegister.OrganizationTreeController, "ServiceRegister.OrganizationTreeController");
    Affecto.Registration.registerController(ServiceRegister.UserController, "ServiceRegister.UserController");
    Affecto.Registration.registerController(ServiceRegister.ServiceController, "ServiceRegister.ServiceController");
    Affecto.Registration.registerController(ServiceRegister.ServiceSearchController, "ServiceRegister.ServiceSearchController");
    Affecto.Registration.registerController(ServiceRegister.LoginController, "ServiceRegister.LoginController");
    Affecto.Registration.registerController(ServiceRegister.UserSearchController, "ServiceRegister.UserSearchController");
}

function registerServices(): void
{
    Affecto.Registration.registerService(ServiceRegister.OrganizationService, "ServiceRegister.OrganizationService");
    Affecto.Registration.registerService(ServiceRegister.SettingsService, "ServiceRegister.SettingsService");
    Affecto.Registration.registerService(ServiceRegister.ValidationService, "ServiceRegister.ValidationService");
    Affecto.Registration.registerService(ServiceRegister.UserService, "ServiceRegister.UserService");
    Affecto.Registration.registerService(ServiceRegister.AuthenticatedUserFactory, "ServiceRegister.AuthenticatedUserFactory");
    Affecto.Registration.registerService(ServiceRegister.ServiceService, "ServiceRegister.ServiceService");
    Affecto.Registration.registerService(ServiceRegister.ClassificationService, "ServiceRegister.ClassificationService");
}

function registerDirectives(): void
{
    Affecto.Registration.registerDirectiveFactory(ServiceRegister.IgnoreDirtyFormFieldFactory, "ServiceRegister.IgnoreDirtyFormField");
    Affecto.Registration.registerDirectiveFactory(ServiceRegister.HelpPopupFactory, "ServiceRegister.HelpPopup");
};

function createTranslations(): angular.translate.ITranslationTable
{
    var translations: angular.translate.ITranslationTable = {};
    translations["ERROR_UNDEFINED"] = "Tapahtui tunnistamaton virhe";
    translations["ERROR_" + ServiceRegister.ErrorCode.insufficientPermissions] = "Ei käyttöoikeuksia";
    translations["UNSAVED_CHANGES_ON_PAGE_LEAVE"] = "Tallentamattomat muutokset menetetään poistuttaessa sivulta.";
    translations["UNSAVED_CHANGES_ON_PAGE_RELOAD"] = "Tallentamattomat muutokset menetetään sivun uudelleenlatauksessa.";
    translations[ServiceRegister.PostalAddressType[ServiceRegister.PostalAddressType.SameAsVisitingAddress]] = "Sama kuin käyntiosoite";
    translations[ServiceRegister.PostalAddressType[ServiceRegister.PostalAddressType.SeparateStreetAddress]] = "Muu osoite";
    translations[ServiceRegister.PostalAddressType[ServiceRegister.PostalAddressType.PostOfficeBoxAddress]] = "PL-osoite";
    return translations;
}