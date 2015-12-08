"use strict";

describe("Service", () =>
{
    var sut: ServiceRegister.Service;

    function assertClassificationCollectionLength(length: number)
    {
        expect(sut.serviceClasses.length).toBe(length);
        expect(sut.targetGroups.length).toBe(length);
        expect(sut.lifeEvents.length).toBe(length);
    }

    describe("Language names", () =>
    {
        it("Language names are listed separated with a comma", () =>
        {
            sut = new ServiceRegister.Service(null, null, null, null, null, null, null, null,
                new Array<ServiceRegister.Language>(new ServiceRegister.Language("fi", "finnish"), new ServiceRegister.Language("en", "english"),
                    new ServiceRegister.Language("sv", "swedish")));
            expect(sut.languageNameList).toEqual("finnish, english, swedish");
        });
        it("Language names collection with one language", () =>
        {
            sut = new ServiceRegister.Service(null, null, null, null, null, null, null, null,
                new Array<ServiceRegister.Language>(new ServiceRegister.Language("fi", "finnish")));
            expect(sut.languageNameList).toEqual("finnish");
        });
        it("Null language names collection", () =>
        {
            sut = new ServiceRegister.Service();
            expect(sut.languageNameList).toEqual("");
        });
        it("Empty language names collection", () =>
        {
            sut = new ServiceRegister.Service(null, null, null, null, null, null, null, null, new Array<ServiceRegister.Language>());
            expect(sut.languageNameList).toEqual("");
        });
    });

    describe("Classification", () =>
    {
        it("Setting null classifications", () =>
        {
            sut = new ServiceRegister.Service();

            sut.setClassification(null, null, null);

            assertClassificationCollectionLength(0);
        });
        it("Setting initial classifications", () =>
        {
            var serviceClasses: Array<ServiceRegister.HierarchicalClass> = new Array<ServiceRegister.HierarchicalClass>(new ServiceRegister.HierarchicalClass("1", "class", null));
            var targetGroups: Array<ServiceRegister.HierarchicalClass> = new Array<ServiceRegister.HierarchicalClass>(new ServiceRegister.HierarchicalClass("3", "class", null));
            var lifeEvents: Array<ServiceRegister.HierarchicalClass> = new Array<ServiceRegister.HierarchicalClass>(new ServiceRegister.HierarchicalClass("4", "class", null));

            sut = new ServiceRegister.Service(null, null, null, null, null, null, null, null, new Array<ServiceRegister.Language>(), serviceClasses, null, targetGroups,
                lifeEvents);

            assertClassificationCollectionLength(1);
            expect(sut.serviceClasses[0]).toBe("1");
            expect(sut.targetGroups[0]).toBe("3");
            expect(sut.lifeEvents[0]).toBe("4");
        });
        it("Updating initial classifications", () =>
        {
            var firstClassification: Array<ServiceRegister.HierarchicalClass> = new Array<ServiceRegister.HierarchicalClass>(new ServiceRegister.HierarchicalClass("1", "class", null));
            var secondClassification: Array<ServiceRegister.HierarchicalClass> = new Array<ServiceRegister.HierarchicalClass>(new ServiceRegister.HierarchicalClass("2", "class", null));
            var thirdClassification: Array<ServiceRegister.HierarchicalClass> = new Array<ServiceRegister.HierarchicalClass>(new ServiceRegister.HierarchicalClass("3", "class", null));
            sut = new ServiceRegister.Service(null, null, null, null, null, null, null, null, new Array<ServiceRegister.Language>(), firstClassification, null, secondClassification,
                thirdClassification);

            sut.setClassification(new ServiceRegister.HierarchicalClasses(thirdClassification), new ServiceRegister.HierarchicalClasses(secondClassification),
                new ServiceRegister.HierarchicalClasses(firstClassification));

            assertClassificationCollectionLength(1);
            expect(sut.serviceClasses[0]).toBe("3");
            expect(sut.targetGroups[0]).toBe("2");
            expect(sut.lifeEvents[0]).toBe("1");
        });
        it("Setting hierarchical classification", () =>
        {
            var child: ServiceRegister.HierarchicalClass = new ServiceRegister.HierarchicalClass("1.1.1", "leaf", null);
            var childAndParent: ServiceRegister.HierarchicalClass = new ServiceRegister.HierarchicalClass("1.1", "child", new Array<ServiceRegister.HierarchicalClass>(child));
            var parent: ServiceRegister.HierarchicalClass = new ServiceRegister.HierarchicalClass("1", "parent", new Array<ServiceRegister.HierarchicalClass>(childAndParent));
            var serviceClasses: ServiceRegister.HierarchicalClasses = new ServiceRegister.HierarchicalClasses(new Array<ServiceRegister.HierarchicalClass>(parent));
            sut = new ServiceRegister.Service();

            sut.setClassification(serviceClasses, null, null);

            expect(sut.serviceClasses.length).toBe(3);
            expect(sut.serviceClasses.indexOf("1")).toBeGreaterThan(-1);
            expect(sut.serviceClasses.indexOf("1.1")).toBeGreaterThan(-1);
            expect(sut.serviceClasses.indexOf("1.1.1")).toBeGreaterThan(-1);
        });
        it("Clearing classification", () =>
        {
            var child: ServiceRegister.HierarchicalClass = new ServiceRegister.HierarchicalClass("1.1.1", "leaf", null);
            var childAndParent: ServiceRegister.HierarchicalClass = new ServiceRegister.HierarchicalClass("1.1", "child", new Array<ServiceRegister.HierarchicalClass>(child));
            var parent: ServiceRegister.HierarchicalClass = new ServiceRegister.HierarchicalClass("1", "parent", new Array<ServiceRegister.HierarchicalClass>(childAndParent));
            var serviceClasses: ServiceRegister.HierarchicalClasses = new ServiceRegister.HierarchicalClasses(new Array<ServiceRegister.HierarchicalClass>(parent));
            sut = new ServiceRegister.Service();

            sut.setClassification(serviceClasses, null, null);
            sut.setClassification(new ServiceRegister.HierarchicalClasses(), null, null);

            assertClassificationCollectionLength(0);
        });
        it("Setting classifications on the same level", () =>
        {
            var child1: ServiceRegister.HierarchicalClass = new ServiceRegister.HierarchicalClass("1.1", "child", null);
            var child2: ServiceRegister.HierarchicalClass = new ServiceRegister.HierarchicalClass("1.2", "child", null);
            var parent1: ServiceRegister.HierarchicalClass = new ServiceRegister.HierarchicalClass("1", "parent", new Array<ServiceRegister.HierarchicalClass>(child1, child2));
            var parent2: ServiceRegister.HierarchicalClass = new ServiceRegister.HierarchicalClass("2", "parent", null);
            var serviceClasses: ServiceRegister.HierarchicalClasses = new ServiceRegister.HierarchicalClasses(new Array<ServiceRegister.HierarchicalClass>(parent1, parent2));
            sut = new ServiceRegister.Service();

            sut.setClassification(serviceClasses, null, null);

            expect(sut.serviceClasses.length).toBe(4);
            expect(sut.serviceClasses.indexOf("1")).toBeGreaterThan(-1);
            expect(sut.serviceClasses.indexOf("2")).toBeGreaterThan(-1);
            expect(sut.serviceClasses.indexOf("1.1")).toBeGreaterThan(-1);
            expect(sut.serviceClasses.indexOf("1.2")).toBeGreaterThan(-1);
        });
    });
});
