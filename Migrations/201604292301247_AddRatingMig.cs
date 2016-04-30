namespace MvcApplicationTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Form1", "FirstName", c => c.String());
            AddColumn("dbo.Form1", "LastName", c => c.String());
            AddColumn("dbo.Form1", "Phone", c => c.String());
            AddColumn("dbo.Form1", "Address1", c => c.String());
            AddColumn("dbo.Form1", "Address2", c => c.String());
            AddColumn("dbo.Form1", "City", c => c.String());
            AddColumn("dbo.Form1", "Postal", c => c.String());
            AddColumn("dbo.Form1", "CoverLetter", c => c.String());
            AddColumn("dbo.Form1", "Resume", c => c.String());
            DropColumn("dbo.Form1", "Title");
            DropColumn("dbo.Form1", "ReleaseDate");
            DropColumn("dbo.Form1", "Genre");
            DropColumn("dbo.Form1", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Form1", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Form1", "Genre", c => c.String());
            AddColumn("dbo.Form1", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Form1", "Title", c => c.String());
            DropColumn("dbo.Form1", "Resume");
            DropColumn("dbo.Form1", "CoverLetter");
            DropColumn("dbo.Form1", "Postal");
            DropColumn("dbo.Form1", "City");
            DropColumn("dbo.Form1", "Address2");
            DropColumn("dbo.Form1", "Address1");
            DropColumn("dbo.Form1", "Phone");
            DropColumn("dbo.Form1", "LastName");
            DropColumn("dbo.Form1", "FirstName");
        }
    }
}
