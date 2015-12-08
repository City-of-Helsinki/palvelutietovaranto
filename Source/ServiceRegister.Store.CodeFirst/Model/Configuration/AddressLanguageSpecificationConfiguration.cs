using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class AddressLanguageSpecificationConfiguration : EntityTypeConfiguration<AddressLanguageSpecification>
    {
        public AddressLanguageSpecificationConfiguration()
        {
            HasKey(specification => new { specification.AddressId, specification.LanguageId });

            Property(specification => specification.StreetAddress).HasMaxLength(200);
            Property(specification => specification.PostalDistrict).HasMaxLength(100);
            Property(specification => specification.Qualifier).HasMaxLength(500);

            HasRequired(specification => specification.Language);
        }
    }
}