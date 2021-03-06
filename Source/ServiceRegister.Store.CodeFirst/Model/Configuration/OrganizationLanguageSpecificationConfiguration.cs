using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class OrganizationLanguageSpecificationConfiguration : EntityTypeConfiguration<OrganizationLanguageSpecification>
    {
        public OrganizationLanguageSpecificationConfiguration()
        {
            HasKey(specification => new { specification.OrganizationId, specification.LanguageId });
            
            Property(specification => specification.Name);
            Property(specification => specification.Description);
            
            HasRequired(specification => specification.Language);
        }
    }
}