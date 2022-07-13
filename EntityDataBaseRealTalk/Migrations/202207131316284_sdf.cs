namespace EntityDataBaseRealTalk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cinemas", "Mainactors_Id", c => c.Int());
            CreateIndex("dbo.Cinemas", "Mainactors_Id");
            AddForeignKey("dbo.Cinemas", "Mainactors_Id", "dbo.Actors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cinemas", "Mainactors_Id", "dbo.Actors");
            DropIndex("dbo.Cinemas", new[] { "Mainactors_Id" });
            DropColumn("dbo.Cinemas", "Mainactors_Id");
        }
    }
}
