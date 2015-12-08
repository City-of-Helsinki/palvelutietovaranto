"use strict";

module Affecto.Login
{
    export class Events
    {
        public static get userLoggedIn(): string
        {
            return "userLoggedIn";
        }

        public static get userLoggedOut(): string
        {
            return "userLoggedOut";
        }

        public static get userChanged(): string
        {
            return "userChanged";
        }
    }
} 