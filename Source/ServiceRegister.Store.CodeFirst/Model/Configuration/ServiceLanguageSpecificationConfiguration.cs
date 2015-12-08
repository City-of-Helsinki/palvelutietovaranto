using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class ServiceLanguageSpecificationConfiguration : EntityTypeConfiguration<ServiceLanguageSpecification>
    {
        public ServiceLanguageSpecificationConfiguration()
        {
            HasKey(specification => new { specification.ServiceId, specification.LanguageId });

            Property(specification => specification.Name).HasMaxLength(100);
            Property(specification => specification.AlternateName).HasMaxLength(100);
            Property(specification => specification.Description).HasMaxLength(4000);
            Property(specification => specification.ShortDescription).HasMaxLength(150);
            Property(specification => specification.Requirements).HasMaxLength(4000);
            Property(specification => specification.UserInstructions).HasMaxLength(4000);

            HasRequired(specification => specification.Language);
        }
    }
}
