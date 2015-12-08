"use strict";

module ServiceRegister
{
    export class Route
    {
        public static get login(): string
        {
            return "/Login";
        }

        public static get frontPage(): string
        {
            return "/";
        }
    }
} 