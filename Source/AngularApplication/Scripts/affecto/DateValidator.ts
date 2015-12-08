"use strict";

module Affecto
{
    export class DateValidator
    {
        private static sqlServerMinimumDate: Date = new Date(1753, 0, 1);

        public static isSqlServerCompatibleFinnishDate(value: any): boolean
        {
            if (this.isFinnishDate(value))
            {
                if (this.isDateType(value))
                {
                    return value >= this.sqlServerMinimumDate;
                }

                var dateParts = this.splitFinnishDate(value);
                var dateObject = new Date(dateParts[2], dateParts[1] - 1, dateParts[0]);
                return dateObject >= this.sqlServerMinimumDate;
            }
            return false;
        }

        public static isFinnishDate(value: any): boolean
        {
            if (!this.isDateType(value))
            {
                var dateObject: Date;
                try
                {
                    var dateParts = this.splitFinnishDate(value);
                    var year = dateParts[2];
                    var month = dateParts[1];
                    var day = dateParts[0];
                    if (!(this.isDayValid(day) && this.isMonthValid(month) && this.isYearValid(year) && this.containsThreeNumericDateParts(dateParts)))
                    {
                        return false;
                    }
                    dateObject = new Date(dateParts[2], month - 1, day);
                }
                catch (e)
                {
                    return false;
                }
                return this.isDateType(dateObject);
            }
            return true;
        }

        public static isDateType(value: any): boolean
        {
            return Object.prototype.toString.call(value) === "[object Date]" && !isNaN(value.getTime());
        }

        private static isYearValid(year: any): boolean
        {
            return year.length === 4;
        }

        private static isMonthValid(month: any): boolean
        {
            return month > 0 && month < 13;
        }

        private static isDayValid(day: any): boolean
        {
            return day > 0 && day < 32;
        }

        private static containsThreeNumericDateParts(dateParts: Array<any>): boolean
        {
            return dateParts.length === 3 && NumberValidator.containsOnlyNumbers(dateParts);
        }

        private static splitFinnishDate(value: any): Array<any>
        {
            return value.split(".");
        }
    }
}