namespace FilExplorer.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUSERIdtoFolderModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Folder", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Folder", "UserID");
        }
    }
}
