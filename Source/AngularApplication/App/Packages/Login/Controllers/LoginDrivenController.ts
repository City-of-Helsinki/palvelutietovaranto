"use strict";

module Affecto.Login
{
    export class LoginDrivenController extends Base.Controller
    {
        private userValue: AuthenticatedUser;

        constructor(protected $scope: angular.IScope, protected authenticationService: IAuthenticationService)
        {
            super($scope);

            $scope.$on(Events.userLoggedIn, this.onUserLoggedInEvent);
            $scope.$on(Events.userLoggedOut, this.onUserLoggedOutEvent);

            if (this.authenticationService.isAuthenticated())
            {
                this.getUser();
            }
        }

        public get isUserLoggedIn(): boolean
        {
            return (this.user != null);
        }

        protected get user(): AuthenticatedUser
        {
            return this.userValue;
        }

        protected set user(user: AuthenticatedUser)
        {
            var newUserAccountName = this.getAccountNameIfSet(user);
            var currentUserAccountName = this.getAccountNameIfSet(this.userValue);

            if (newUserAccountName !== currentUserAccountName)
            {
                this.$scope.$root.$broadcast(Events.userChanged);
            }

            this.userValue = user;
        }

        protected onUserLoggedIn(): void
        {
        }

        protected onUserLoggedOut(): void
        {
        }

        private getAccountNameIfSet(user: AuthenticatedUser): string
        {
            return user != null ? user.accountName : null;
        }

        private getUser(): void
        {
            this.user = this.authenticationService.getUser();
        }

        private onUserLoggedInEvent = (event: angular.IAngularEvent): void =>
        {
            this.getUser();
            this.onUserLoggedIn();
        }

        private onUserLoggedOutEvent = (event: angular.IAngularEvent): void =>
        {
            this.user = null;
            this.onUserLoggedOut();
        }
    }
}