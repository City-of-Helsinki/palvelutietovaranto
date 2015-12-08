using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            HasKey(address => address.Id);

            Property(address => address.PostOfficeBox).HasMaxLength(100);
            Property(address => address.PostalCode).HasMaxLength(100);

            HasMany(address => address.LanguageSpecifications).WithRequired().HasForeignKey(a => a.AddressId);
        }
    }
}