"use strict";

describe("languages", () =>
{
    var sut: ServiceRegister.Languages;

    describe("comma separated name list", () =>
    {
        it("name list is empty when language collection is null", () =>
        {
            sut = new ServiceRegister.Languages(null);
            expect(sut.commaSeparatedNames).toEqual("");
        });
        it("name list is empty when language collection is empty", () =>
        {
            sut = new ServiceRegister.Languages(new Array<ServiceRegister.Language>());
            expect(sut.commaSeparatedNames).toEqual("");
        });
        it("multiple languages", () =>
        {
            sut = new ServiceRegister.Languages(new Array<ServiceRegister.Language>(new ServiceRegister.Language("fi", "suomi"), new ServiceRegister.Language("sv", "ruotsi"),
                new ServiceRegister.Language("en", "englanti")));
            expect(sut.commaSeparatedNames).toEqual("suomi, ruotsi, englanti");
        });
        it("one language needs no separator", () =>
        {
            sut = new ServiceRegister.Languages(new Array<ServiceRegister.Language>(new ServiceRegister.Language("fi", "suomi")));
            expect(sut.commaSeparatedNames).toEqual("suomi");
        });
    });

    describe("codes", () =>
    {
        it("no codes when language collection is null", () =>
        {
            sut = new ServiceRegister.Languages(null);
            expect(sut.codes.length).toEqual(0);
        });
        it("no codes when language collection is empty", () =>
        {
            sut = new ServiceRegister.Languages(new Array<ServiceRegister.Language>());
            expect(sut.codes.length).toEqual(0);
        });
        it("multiple languages", () =>
        {
            sut = new ServiceRegister.Languages(new Array<ServiceRegister.Language>(new ServiceRegister.Language("fi", "suomi"), new ServiceRegister.Language("sv", "ruotsi"),
                new ServiceRegister.Language("en", "englanti")));
            expect(sut.codes).toContain("fi");
            expect(sut.codes).toContain("en");
            expect(sut.codes).toContain("sv");
            expect(sut.codes.length).toEqual(3);
        });
        it("one language", () =>
        {
            sut = new ServiceRegister.Languages(new Array<ServiceRegister.Language>(new ServiceRegister.Language("fi", "suomi")));
            expect(sut.codes).toContain("fi");
            expect(sut.codes.length).toEqual(1);
        });
    });

    describe("filter", () =>
    {
        it("language collection is null", () =>
        {
            sut = new ServiceRegister.Languages(null);
            expect(sut.filter(null).length).toEqual(0);
        });
        it("language collection is empty", () =>
        {
            sut = new ServiceRegister.Languages(new Array<ServiceRegister.Language>());
            expect(sut.filter(null).length).toEqual(0);
        });
        it("codes filter is null", () =>
        {
            var expectedResult = new ServiceRegister.Language("fi", "suomi");
            sut = new ServiceRegister.Languages(new Array<ServiceRegister.Language>(expectedResult));
            expect(sut.filter(null).length).toEqual(0);
        });
        it("codes filter is empty", () =>
        {
            var expectedResult = new ServiceRegister.Language("fi", "suomi");
            sut = new ServiceRegister.Languages(new Array<ServiceRegister.Language>(expectedResult));
            expect(sut.filter(new Array<string>()).length).toEqual(0);
        });
        it("codes filter contains all languages", () =>
        {
            var expectedResult1 = new ServiceRegister.Language("fi", "suomi");
            var expectedResult2 = new ServiceRegister.Language("sv", "ruotsi");
            var filter = new Array<string>("fi", "sv");
            sut = new ServiceRegister.Languages(new Array<ServiceRegister.Language>(expectedResult1, expectedResult2));
            var result = sut.filter(filter);
            expect(result.length).toEqual(2);
            expect(result[0]).toEqual(expectedResult1);
            expect(result[1]).toEqual(expectedResult2);
        });
        it("codes filter contains some of the languages", () =>
        {
            var expectedResult = new ServiceRegister.Language("fi", "suomi");
            var filter = new Array<string>("fi");
            sut = new ServiceRegister.Languages(new Array<ServiceRegister.Language>(expectedResult, new ServiceRegister.Language("sv", "ruotsi"),
                new ServiceRegister.Language("en", "englanti")));
            var result = sut.filter(filter);
            expect(result.length).toEqual(1);
            expect(result[0]).toEqual(expectedResult);
        });
    });
});
 