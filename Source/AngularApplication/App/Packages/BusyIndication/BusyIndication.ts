"use strict";

angular.module("Affecto.BusyIndication", []);

Affecto.Registration.registerService(Affecto.BusyIndication.BusyIndicationService, "Affecto.BusyIndication.BusyIndicationService");
Affecto.Registration.registerDirectiveFactory(Affecto.BusyIndication.BusyIndicatorFactory, "Affecto.BusyIndication.BusyIndicator");