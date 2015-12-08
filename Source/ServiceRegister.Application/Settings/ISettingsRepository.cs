using System.Collections.Generic;

namespace ServiceRegister.Application.Settings
{
    public interface ISettingsRepository
    {
        IReadOnlyCollection<string> GetOrganizationTypeNames();
        IReadOnlyCollection<string> GetDataLanguageCodes();
        IReadOnlyCollection<ILanguage> GetServiceLanguages();
        IReadOnlyCollection<string> GetWebPageTypes();
    }
}
