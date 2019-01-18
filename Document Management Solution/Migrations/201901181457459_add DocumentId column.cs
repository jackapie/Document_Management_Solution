namespace Document_Management_Solution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDocumentIdcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentModels", "DocumentId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocumentModels", "DocumentId");
        }
    }
}
