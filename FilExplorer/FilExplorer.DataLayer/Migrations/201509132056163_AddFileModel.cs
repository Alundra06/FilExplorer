namespace FilExplorer.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileModel : DbMigration
    {
        public override void Up()
        {
          
            
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                        FilePath = c.String(),
                        FolderPath = c.String(),
                        FolderID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.Folder", t => t.FolderID)
                .Index(t => t.FolderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "FolderID", "dbo.Folder");
            DropIndex("dbo.File", new[] { "FolderID" });
            DropTable("dbo.File");
        }
    }
}
