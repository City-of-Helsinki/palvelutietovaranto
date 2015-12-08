using Affecto.EntityFramework.PostgreSql;

namespace ServiceRegister.Store.CodeFirst.Migrations
{
    internal sealed class Configuration : HistoryContextDbMigrationsConfiguration<StoreContext>
    {
        public Configuration()
            : base(PostgreSqlConfiguration.Settings.Schemas[StoreContext.ConfigurationKey])
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}