namespace ServiceRegister.Store.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSourceIdAndOrderNumberToOrganizationType : ServiceRegisterDbMigration
    {
        public override void Up()
        {
            AddColumn("organizationtype", "sourceid", c => c.String(maxLength: 200));
            AddColumn("organizationtype", "ordernumber", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("organizationtype", "ordernumber");
            DropColumn("organizationtype", "sourceid");
        }
    }
}
