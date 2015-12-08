using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class ServiceClassConfiguration : EntityTypeConfiguration<ServiceClass>
    {
        public ServiceClassConfiguration()
        {
            HasKey(serviceClass => serviceClass.Id);
            Property(serviceClass => serviceClass.Name).HasMaxLength(200);
            Property(serviceClass => serviceClass.SourceId).HasMaxLength(200);
            Property(serviceClass => serviceClass.SourceParentId).HasMaxLength(200);
        }
    }
}
