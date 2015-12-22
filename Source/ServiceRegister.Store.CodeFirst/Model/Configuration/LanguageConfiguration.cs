using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class LanguageConfiguration : EntityTypeConfiguration<Language>
    {
        public LanguageConfiguration()
        {
            HasKey(language => language.Id);
            
            Property(language => language.Code).IsRequired();
            Property(language => language.Name).IsRequired();
        }
    }
}