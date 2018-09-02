namespace BusinessRep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AspNetUsers", "BusinessName", c => c.String(maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 200));
            AddColumn("dbo.AspNetUsers", "ProfilePhotoFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePhotoFileName");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "BusinessName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
