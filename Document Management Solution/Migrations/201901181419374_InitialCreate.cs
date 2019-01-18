namespace Document_Management_Solution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentTitle = c.String(),
                        File = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DocumentModels");
        }
    }
}
