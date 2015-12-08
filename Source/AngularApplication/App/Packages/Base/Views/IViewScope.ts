"use strict";

module Affecto.Base
{
    export interface IViewScope extends IControllerScope
    {
        model: IModel
    }
}