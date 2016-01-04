namespace FilExplorer.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Folder",
                c => new
                    {
                        FolderID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        ParentFolder = c.String(),
                        FullPath = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.FolderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Folder");
        }
    }
}
