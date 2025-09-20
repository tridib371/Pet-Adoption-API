namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateShelterDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shelters", "Address", c => c.String(nullable: false, maxLength: 255, unicode: false));
            AlterColumn("dbo.Shelters", "Phone", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Shelters", "Email", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shelters", "Email", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Shelters", "Phone", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Shelters", "Address", c => c.String(maxLength: 255, unicode: false));
        }
    }
}
