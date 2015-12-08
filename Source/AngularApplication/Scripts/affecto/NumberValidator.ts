"use strict";

module Affecto
{
    export class NumberValidator
    {
        public static containsOnlyNumbers(items: Array<any>): boolean
        {
            if (items == null || items.length === 0)
            {
                return false;
            }

            return items.every((item: any) =>
            {
                return item === 0 || (item !== "" && !isNaN(item));
            });
        }
    }
}