namespace PB.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
