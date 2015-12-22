using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class OrganizationTypeConfiguration : EntityTypeConfiguration<OrganizationType>
    {
        public OrganizationTypeConfiguration()
        {
            HasKey(organizationType => organizationType.Id);

            Property(organizationType => organizationType.Name).IsRequired();
            Property(organizationType => organizationType.SourceId);

        }
    }
}