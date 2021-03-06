﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ServiceRegister.Application.Service;
using ServiceRegister.Common;
using ServiceRegister.Store.CodeFirst;
using ServiceRegister.Store.CodeFirst.Model;

namespace ServiceRegister.Store.Tests.Model
{
    [TestClass]
    public class ServiceTests
    {
        private Service sut;
        private IStoreContext context;

        [TestInitialize]
        public void Setup()
        {
            context = Substitute.For<IStoreContext>();
            sut = new Service();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SettingBasicInformationDataForLanguageNotInDataLanguages()
        {
            const string languageCode = "sv";
            IBasicInformation info = Substitute.For<IBasicInformation>();
            info.Names.Returns(new List<LocalizedText> { new LocalizedText(languageCode, "namn") });
            context.GetDataLanguage(languageCode).Returns(x => { throw new ArgumentException(); });

            sut.SetBasicInformation(info, context);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SettingLanguageForLanguageNotInServiceLanguages()
        {
            const string languageCode = "sv";
            IBasicInformation info = Substitute.For<IBasicInformation>();
            info.LanguagesCodes.Returns(new List<string> { languageCode });
            context.GetServiceLanguage(languageCode).Returns(x => { throw new ArgumentException(); });

            sut.SetBasicInformation(info, context);
        }
    }
}
