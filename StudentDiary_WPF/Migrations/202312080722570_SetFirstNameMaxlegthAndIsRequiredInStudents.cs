﻿namespace StudentDiary_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetFirstNameMaxlegthAndIsRequiredInStudents : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String());
        }
    }
}
