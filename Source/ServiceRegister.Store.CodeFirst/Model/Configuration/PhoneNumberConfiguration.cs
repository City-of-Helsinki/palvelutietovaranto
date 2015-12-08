using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class PhoneNumberConfiguration : EntityTypeConfiguration<PhoneNumber>
    {
        public PhoneNumberConfiguration()
        {
            HasKey(phoneNumber => phoneNumber.Id);

            Property(phoneNumber => phoneNumber.Number).IsRequired().HasMaxLength(50);
            Property(phoneNumber => phoneNumber.PhoneCallFee).HasMaxLength(150);
        }
    }
}