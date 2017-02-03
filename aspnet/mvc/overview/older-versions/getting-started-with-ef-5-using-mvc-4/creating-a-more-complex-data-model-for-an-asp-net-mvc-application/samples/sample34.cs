CreateTable(
        "dbo.CourseInstructor",
        c => new
            {
                CourseID = c.Int(nullable: false),
                InstructorID = c.Int(nullable: false),
            })
        .PrimaryKey(t => new { t.CourseID, t.InstructorID })
        .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
        .ForeignKey("dbo.Instructor", t => t.InstructorID, cascadeDelete: true)
        .Index(t => t.CourseID)
        .Index(t => t.InstructorID);

    // Create  a department for course to point to.
    Sql("INSERT INTO dbo.Department (Name, Budget, StartDate) VALUES ('Temp', 0.00, GETDATE())");
    //  default value for FK points to department created above.
    AddColumn("dbo.Course", "DepartmentID", c => c.Int(nullable: false, defaultValue: 1)); 
    //AddColumn("dbo.Course", "DepartmentID", c => c.Int(nullable: false));

    AlterColumn("dbo.Course", "Title", c => c.String(maxLength: 50));
    AddForeignKey("dbo.Course", "DepartmentID", "dbo.Department", "DepartmentID", cascadeDelete: true);
    CreateIndex("dbo.Course", "DepartmentID");
}

public override void Down()
{