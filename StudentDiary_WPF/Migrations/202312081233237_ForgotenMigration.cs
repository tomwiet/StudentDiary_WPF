namespace StudentDiary_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForgotenMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ratings", "Rate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "Rate", c => c.String());
        }
    }
}
