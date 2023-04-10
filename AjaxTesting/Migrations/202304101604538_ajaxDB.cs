namespace AjaxTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajaxDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Family = c.String(nullable: false, maxLength: 20),
                        Phonenumber = c.String(nullable: false, maxLength: 15),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
