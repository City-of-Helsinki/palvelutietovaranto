using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class OrganizationLanguageSpecificationConfiguration : EntityTypeConfiguration<OrganizationLanguageSpecification>
    {
        public OrganizationLanguageSpecificationConfiguration()
        {
            HasKey(specification => new { specification.OrganizationId, specification.LanguageId });
            
            Property(specification => specification.Name).HasMaxLength(500);
            Property(specification => specification.Description).HasMaxLength(4000);
            
            HasRequired(specification => specification.Language);
        }
    }
}