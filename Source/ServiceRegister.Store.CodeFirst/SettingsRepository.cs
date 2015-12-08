using System;
using System.Collections.Generic;
using System.Linq;
using ServiceRegister.Application;
using ServiceRegister.Application.Settings;
using ServiceRegister.Store.CodeFirst.Model;

namespace ServiceRegister.Store.CodeFirst
{
    internal class SettingsRepository : ISettingsRepository
    {
        private readonly IStoreContext context;

        public SettingsRepository(IStoreContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.context = context;
        }

        public IReadOnlyCollection<string> GetOrganizationTypeNames()
        {
            return context.OrganizationTypes.OrderBy(pt => pt.OrderNumber).Select(pt => pt.Name).ToList();
        }

        public IReadOnlyCollection<string> GetDataLanguageCodes()
        {
            return context.DataLanguages.Select(language => language.Language.Code).ToList();
        }

        public IReadOnlyCollection<ILanguage> GetServiceLanguages()
        {
            List<AvailableServiceLanguage> dbLanguages = context.ServiceLanguages.ToList();
            IEnumerable<ILanguage> languages = dbLanguages
                .Select(dbLanguage => LanguageFactory.CreateLanguage(dbLanguage.Language.Code, dbLanguage.Language.Name, dbLanguage.OrderNumber));
            OrderableCollection<ILanguage> serviceLanguages = new OrderableCollection<ILanguage>(languages);
            return serviceLanguages.Order().ToList();
        }

        public IReadOnlyCollection<string> GetWebPageTypes()
        {
            return context.WebPageTypes.Select(t => t.Type).ToList();
        }
    }
}