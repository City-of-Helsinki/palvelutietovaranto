using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class OrganizationTypeConfiguration : EntityTypeConfiguration<OrganizationType>
    {
        public OrganizationTypeConfiguration()
        {
            HasKey(organizationType => organizationType.Id);

            Property(organizationType => organizationType.Name).IsRequired().HasMaxLength(200);
            Property(organizationType => organizationType.SourceId).HasMaxLength(200);

        }
    }
}