namespace CodeFirst_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Family = c.String(nullable: false, maxLength: 30),
                        Phonenumber = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_Students");
        }
    }
}
