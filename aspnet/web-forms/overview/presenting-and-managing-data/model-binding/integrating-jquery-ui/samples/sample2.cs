namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnrollmentDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "EnrollmentDate", c => 
              c.DateTime(nullable: false, defaultValue: new DateTime(2013, 1, 1)));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "EnrollmentDate");
        }
    }
}