"use strict";

module Affecto
{
    export class Compare
    {
        public static numbers(value1: number, value2: number): number
        {
            if (value1 == null)
            {
                return value2 == null ? 0 : -1;
            }
            if (value2 == null)
            {
                return 1;
            }
            if (value1 > value2)
            {
                return 1;
            }
            if (value1 < value2)
            {
                return -1;
            }
            return 0;
        }

        public static strings(text1: string, text2: string): number
        {
            if (text1 == null && text2 == null)
            {
                return 0;
            }
            if (text1 == null)
            {
                return -1;
            }
            if (text2 == null)
            {
                return 1;
            }

            var comparableText1: string = text1.toLowerCase();
            var comparableText2: string = text2.toLowerCase();
            if (comparableText1 > comparableText2)
            {
                return 1;
            }
            if (comparableText1 < comparableText2)
            {
                return -1;
            }
            return 0;
        }

        public static dates(date1: Date, date2: Date): number
        {
            if (date1 == null && date2 == null)
            {
                return 0;
            }
            if (date1 == null)
            {
                return -1;
            }
            if (date2 == null)
            {
                return 1;
            }

            if (date1 > date2)
            {
                return 1;
            }
            if (date1 < date2)
            {
                return -1;
            }
            return 0;
        }

        public static caseInsensitiveEquals(text1: string, text2: string): boolean
        {
            if (text1 == null && text2 == null)
            {
                return true;
            }
            if (text1 == null || text2 == null)
            {
                return false;
            }
            return text1.toLowerCase() === text2.toLowerCase();
        }
    }
}