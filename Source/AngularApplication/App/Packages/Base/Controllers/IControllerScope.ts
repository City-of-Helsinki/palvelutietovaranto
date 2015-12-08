"use strict";

module Affecto.Base
{
    export interface IControllerScope extends angular.IScope
    {
        controller: IController
    }
}