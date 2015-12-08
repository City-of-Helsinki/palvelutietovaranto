module Affecto.Base
{
    export interface IDirective extends angular.IDirective
    {
        restrict: string;
        link($scope: angular.IScope, element: JQuery, attributes?: angular.IAttributes, controller?: any): any;
    }
} 