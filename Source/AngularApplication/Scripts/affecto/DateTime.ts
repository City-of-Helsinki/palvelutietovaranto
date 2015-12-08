"use strict";

module Affecto
{
    export class DateTime
    {
        public static get today(): Date
        {
            var now: Date = new Date();
            return new Date(now.getFullYear(), now.getMonth(), now.getDate());
        }
    }
}