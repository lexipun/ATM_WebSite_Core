namespace ATM_WebSite_Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ATM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberOfCard = c.String(),
                        PinCode = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Name = c.String(),
                        CountMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .Index(t => t.CardId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "CardId", "dbo.Cards");
            DropIndex("dbo.Transactions", new[] { "CardId" });
            DropIndex("dbo.Cards", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Transactions");
            DropTable("dbo.Cards");
        }
    }
}
