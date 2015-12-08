"use strict";

module Affecto.Registration
{
    function getModuleName(typeName: string)
    {
        var index: number = typeName.lastIndexOf(".");
        return typeName.slice(0, index);
    }

    function getClassName(typeName: string)
    {
        var index: number = typeName.lastIndexOf(".");
        return typeName.slice(index + 1);
    }

    export function registerController(type: any, typeName: string)
    {
        var moduleName: string = getModuleName(typeName);
        angular.module(moduleName).controller(typeName, type);
    }

    export function registerDirectiveFactory(factory: angular.IDirectiveFactory, directiveTypeName: string)
    {
        var moduleName: string = getModuleName(directiveTypeName);
        var className: string = getClassName(directiveTypeName);
        var directiveName: string = "affecto" + className;

        angular.module(moduleName).directive(directiveName, factory);
    }

    export function registerService(type: any, typeName: string)
    {
        var moduleName: string = getModuleName(typeName);
        var className: string = getClassName(typeName);
        var serviceName: string = className[0].toLowerCase() + className.slice(1);

        angular.module(moduleName).service(serviceName, type);
    }
} 