namespace MvcApplicationTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingMig1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Form1", "CoverLetter", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Form1", "CoverLetter", c => c.String());
        }
    }
}
