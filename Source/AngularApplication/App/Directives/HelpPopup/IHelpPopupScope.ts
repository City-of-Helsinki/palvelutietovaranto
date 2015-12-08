"use strict";

module ServiceRegister
{
    export interface IHelpPopupScope extends angular.IScope
    {
        paragraphs: Array<string>;
        helpTextVisible: boolean;
    }
} 