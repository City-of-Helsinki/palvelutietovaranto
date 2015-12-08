using System;
using System.Collections.Generic;
using ServiceRegister.Common;

namespace ServiceRegister.Application.Service
{
    public interface IBasicInformation
    {
        IEnumerable<LocalizedText> Names { get; }
        IEnumerable<LocalizedText> AlternateNames { get; }
        IEnumerable<LocalizedText> Descriptions { get; }
        IEnumerable<LocalizedText> ShortDescriptions { get; }
        IEnumerable<LocalizedText> UserInstructions { get; }
        IEnumerable<Language> Languages { get; }
        IEnumerable<string> LanguagesCodes { get; }
        IEnumerable<LocalizedText> Requirements { get; }
        string GetAlternateName(string languageCode);
        string GetDescription(string languageCode);
        string GetShortDescription(string languageCode);
        string GetUserInstructions(string languageCode);
        string GetRequirements(string languageCode);
    }
}
