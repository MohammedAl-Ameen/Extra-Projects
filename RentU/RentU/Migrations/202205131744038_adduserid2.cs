namespace RentU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduserid2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Additems", "Userid", c => c.String(maxLength: 128));
            CreateIndex("dbo.Additems", "Userid");
            AddForeignKey("dbo.Additems", "Userid", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Additems", "Userid", "dbo.AspNetUsers");
            DropIndex("dbo.Additems", new[] { "Userid" });
            AlterColumn("dbo.Additems", "Userid", c => c.String());
        }
    }
}
