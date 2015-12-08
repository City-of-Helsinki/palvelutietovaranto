using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class TargetGroupConfiguration : EntityTypeConfiguration<TargetGroup>
    {
        public TargetGroupConfiguration()
        {
            HasKey(lifeEvent => lifeEvent.Id);
            Property(lifeEvent => lifeEvent.Name).HasMaxLength(200);
            Property(lifeEvent => lifeEvent.SourceId).HasMaxLength(200);
            Property(lifeEvent => lifeEvent.SourceParentId).HasMaxLength(200);
        }
    }
}
