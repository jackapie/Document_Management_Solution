namespace Document_Management_Solution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFileNamecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocumentModels", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocumentModels", "FileName");
        }
    }
}
