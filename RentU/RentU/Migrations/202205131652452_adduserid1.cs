namespace RentU.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduserid1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Items", name: "User_Id", newName: "userId");
            RenameIndex(table: "dbo.Items", name: "IX_User_Id", newName: "IX_userId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Items", name: "IX_userId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Items", name: "userId", newName: "User_Id");
        }
    }
}
