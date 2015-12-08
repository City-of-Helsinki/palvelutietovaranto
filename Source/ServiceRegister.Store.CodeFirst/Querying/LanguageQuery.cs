using System;
using System.Linq;
using ServiceRegister.Store.CodeFirst.Model;

namespace ServiceRegister.Store.CodeFirst.Querying
{
    internal class LanguageQuery
    {
        private readonly IQueryable<ILanguageReference> languages;

        public LanguageQuery(IQueryable<ILanguageReference> languages)
        {
            if (languages == null)
            {
                throw new ArgumentNullException("languages");
            }
            this.languages = languages;
        }

        public ILanguageReference Execute(string languageCode)
        {
            try
            {
                return languages.Single(lang => lang.Language.Code.Equals(languageCode, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception e)
            {
                throw new ArgumentException(string.Format("Language '{0}' not found or not usable in this context.", languageCode), "languageCode", e);
            }
        }
    }
}