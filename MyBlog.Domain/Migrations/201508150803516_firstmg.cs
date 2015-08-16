namespace MyBlog.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlSlug = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        Meta = c.String(),
                        UrlSlug = c.String(),
                        Published = c.Boolean(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Category", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlSlug = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.TagPost",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Post_PostId })
                .ForeignKey("dbo.Tag", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Post_PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPost", "Post_PostId", "dbo.Post");
            DropForeignKey("dbo.TagPost", "Tag_TagId", "dbo.Tag");
            DropForeignKey("dbo.Post", "Category_CategoryId", "dbo.Category");
            DropIndex("dbo.TagPost", new[] { "Post_PostId" });
            DropIndex("dbo.TagPost", new[] { "Tag_TagId" });
            DropIndex("dbo.Post", new[] { "Category_CategoryId" });
            DropTable("dbo.TagPost");
            DropTable("dbo.Tag");
            DropTable("dbo.Post");
            DropTable("dbo.Category");
        }
    }
}
