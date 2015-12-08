using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class ServiceKeywordConfiguration : EntityTypeConfiguration<ServiceKeyword>
    {
        public ServiceKeywordConfiguration()
        {
            HasKey(keyword => keyword.Id);

            Property(keyword => keyword.Keyword).HasMaxLength(4000).IsRequired();

            HasRequired(keyword => keyword.Service);
            HasRequired(keyword => keyword.Language);
        }
    }
}
