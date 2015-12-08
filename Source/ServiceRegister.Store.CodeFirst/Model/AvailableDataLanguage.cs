using System;

namespace ServiceRegister.Store.CodeFirst.Model
{
    public class AvailableDataLanguage : ILanguageReference
    {
        public Guid LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
