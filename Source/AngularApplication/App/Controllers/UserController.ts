"use strict";

module ServiceRegister
{
    export class UserController implements Affecto.Base.IController
    {
        public static $inject = [
            "$scope", "$location", "$routeParams", "$sce", "$q", "userService", "settingsService", "validationService", "busyIndicationService", "organizationService", "authenticationService"
        ];

        public organizations: Array<OrganizationName>;
        public userRoles: Array<UserRole>;

        public validPhoneNumber: boolean;
        public validEmailAddress: boolean;
        public existingEmailAddress: boolean;
        public validPassword: boolean;
        public model: User;
        public originalModel: User;

        public userInformationForm: angular.IFormController;
        public userInformationBeingEdited: boolean;
       

       
        constructor(private $scope: Affecto.Base.IViewScope, private $location: angular.ILocationService, $routeParams: IUserRoute, private $sce: angular.ISCEService,
            private $q: angular.IQService, private userService: UserService, private settingsService: SettingsService, private validationService: ValidationService,
            private busyIndicationService: Affecto.BusyIndication.IBusyIndicationService, private organizationService: OrganizationService, private authenticationService: Affecto.Login.IAuthenticationService)
        {

            var user: AuthenticatedUser = authenticationService.getUser<AuthenticatedUser>();
            if (!user.hasPermission(Permission.userMaintenance))
            {
                this.$location.path(Affecto.ExceptionHandling.Routes.error).search("code", ErrorCode.insufficientPermissions);
            }
           
            this.initializeUser($routeParams);

            $scope.controller = this;
            $scope.model = this.model;
       
            this.validPhoneNumber = true;
            this.validEmailAddress = true;
            this.existingEmailAddress = false;
            this.validPassword = true;

            this.userInformationBeingEdited = false;

            this.initializeSelectionLists();
        }

        public canSave(): boolean
        {
            return this.validPhoneNumber && this.validEmailAddress && !this.existingEmailAddress && this.validPassword;
        }

        public cancelEditing(): void
        {
            this.model = this.originalModel;
            this.userInformationBeingEdited = false;
        }

        public cancelAdd(): void
        {
           this.goToHomePage();
        }

        public goToHomePage(): void
        {
            this.$location.path("/Organizations/" + this.model.organizationId + "/Users");
        }

        public editUserInformation(): void
        {
            this.originalModel = angular.copy(this.model);
            this.validateEmailAddress();
            this.validatePhoneNumber();
            this.validatePassword();
            this.userInformationForm.$setPristine();
            this.userInformationBeingEdited = true;
        }

        public isUserInformationBeingEdited(): boolean
        {
            return this.userInformationBeingEdited;
        }

        public saveUserInformation(): angular.IPromise<void>
        {
            if (this.isModelChanged())
            {
                return this.saveUser(true);
            }
        }

        public addUserInformation(): angular.IPromise<void>
        {
            return this.addUser(true);
        }

        public validateEmailAddress(): void
        {
            if (this.model.hasEmailAddress())
            {
                this.$q.all([this.validationService.validateEmailAddress(this.model.emailAddress), this.userService.isExistingUser(this.model.emailAddress)])
                    .then((result: Array<any>) =>
                    {
                        this.setEmailAddressValidity(result[0], result[1]);
                    });
            }
            else
            {
                this.setEmailAddressValidity(true, false);
            }
        }

        public validatePhoneNumber(): void
        {
            if (this.model.hasPhoneNumber())
            {
                this.validationService.validatePhoneNumber(this.model.phoneNumber)
                    .then(this.setPhoneNumberValidity);
            }
            else
            {
                this.setPhoneNumberValidity(true);
            }
        }

        public validatePassword(): void
        {
            if (this.model.hasPassword())
            {
                this.setPasswordValidity(this.model.password === this.model.passwordConfirm);
            }
            else
            {
                this.setPasswordValidity(true);
            }
        }

        private isModelChanged(): boolean
        {
            return !angular.equals(this.model, this.originalModel);
        }

        private setEmailAddressValidity = (isValid: boolean, isExisting: boolean): void =>
        {
            this.validEmailAddress = isValid;
            this.existingEmailAddress = isExisting;
            this.setFormFieldValidity("emailAddress", isValid && !isExisting);
        }

        private setPhoneNumberValidity = (isValid: boolean): void =>
        {
            this.validPhoneNumber = isValid;
            this.setFormFieldValidity("phoneNumber", isValid);
        }

        private setPasswordValidity = (isValid: boolean): void =>
        {
            this.validPassword = isValid;
            this.setFormFieldValidity("passwordConfirm", isValid);
        }

        private setFormFieldValidity = (fieldName: string, isValid: boolean): void =>
        {
            if (this.userInformationForm[fieldName] != null)
            {
                this.userInformationForm[fieldName].$setValidity("format", isValid);
            }
        }

        private initializeUser($routeParams: IUserRoute): angular.IPromise<void>
        {
            if ($routeParams.id === undefined || $routeParams.id == null)
            {
                this.model = new User();
                this.model.organizationId = $routeParams.organizationId;
            }
            else
            {
                this.busyIndicationService.showBusyIndicator("Haetaan käyttäjän tietoja...");
                return this.userService.getUser($routeParams.id)
                    .then((user: User) =>
                    {
                        this.model = user;
                        this.busyIndicationService.hideBusyIndicator();
                    });
            }

            this.originalModel = angular.copy(this.model);
        }

        private saveUser(goToHomePage: boolean)
        {
            this.busyIndicationService.showBusyIndicator("Tallennetaan käyttäjän tietoja...");
            this.originalModel = angular.copy(this.model);

            return this.userService.setUser(this.model)
                .then(() =>
                {
                    this.busyIndicationService.hideBusyIndicator();
                    if (goToHomePage)
                    {
                        this.goToHomePage();
                    }
                });
        }

        private addUser(goToHomePage: boolean)
        {
            this.busyIndicationService.showBusyIndicator("Tallennetaan käyttäjän tietoja...");
            this.originalModel = angular.copy(this.model);

            return this.userService.addUser(this.model)
                .then((userId: string) =>
                {
                    this.busyIndicationService.hideBusyIndicator();
                    if (goToHomePage)
                    {
                        this.goToHomePage();
                    }
                });
        }

        private initializeSelectionLists(): angular.IPromise<void>
        {
            this.busyIndicationService.showBusyIndicator("Haetaan valintalistojen sisältöä...");
            return this.organizationService.getMainOrganizations()
                .then((orgs: Array<OrganizationName>) =>
                {
                    this.organizations = orgs;
                    this.settingsService.getUserRoles()
                        .then((roles: Array<UserRole>) =>
                        {
                            this.userRoles = roles;
                            this.busyIndicationService.hideBusyIndicator();
                });
                });
        }
    }
}