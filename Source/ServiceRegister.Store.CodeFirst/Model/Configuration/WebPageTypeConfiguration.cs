using System.Data.Entity.ModelConfiguration;

namespace ServiceRegister.Store.CodeFirst.Model.Configuration
{
    internal class WebPageTypeConfiguration : EntityTypeConfiguration<WebPageType>
    {
        public WebPageTypeConfiguration()
        {
            HasKey(webPageType => webPageType.Id);

            Property(webPageType => webPageType.Type).IsRequired().HasMaxLength(200);
        }
    }
}