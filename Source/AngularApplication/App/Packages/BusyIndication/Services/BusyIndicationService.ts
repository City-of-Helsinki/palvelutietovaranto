"use strict";

module Affecto.BusyIndication
{
    export interface IBusyIndicationService
    {
        showBusyIndicator(text: string): void;
        hideBusyIndicator(): void;
    }

    export class BusyIndicationService implements IBusyIndicationService
    {
        public static $inject = ["$rootScope"];

        constructor(private $rootScope: angular.IRootScopeService)
        {
        }

        public showBusyIndicator(text: string): void
        {
            this.$rootScope.$broadcast(Events.toggleBusyIndicator, true, text);
        }

        public hideBusyIndicator(): void
        {
            this.$rootScope.$broadcast(Events.toggleBusyIndicator, false, null);
        }
    }
}