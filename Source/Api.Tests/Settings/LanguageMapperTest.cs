﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ServiceRegister.Api.Settings;
using ServiceRegister.Application.Settings;
using ServiceRegister.Common;

namespace ServiceRegister.Api.Tests.Settings
{
    [TestClass]
    public class LanguageMapperTest
    {
        private LanguageMapper sut;
        private ILanguage source;
        private Language destination;

        [TestInitialize]
        public void Setup()
        {
            source = Substitute.For<ILanguage>();
            sut = new LanguageMapper();
        }

        [TestMethod]
        public void LanguageCodeIsMapped()
        {
            source.Code.Returns("fi");
            destination = sut.Map(source);
            Assert.AreEqual(source.Code, destination.Code);
        }

        [TestMethod]
        public void LanguageNameIsMapped()
        {
            source.Name.Returns("Finnish");
            destination = sut.Map(source);
            Assert.AreEqual(source.Name, destination.Name);
        }
    }
}
