"use strict";

module Affecto.BusyIndication
{
    export interface IBusyIndicatorScope extends angular.IScope
    {
        isBusy: boolean;
        busyIndicatorText: string;
    }
} 