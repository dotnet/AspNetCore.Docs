public override void Up()
{
    DropForeignKey("dbo.Department", "InstructorID", "dbo.Instructor");
    DropForeignKey("dbo.OfficeAssignment", "InstructorID", "dbo.Instructor");
    DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Student");
    DropForeignKey("dbo.CourseInstructor", "InstructorID", "dbo.Instructor");
    DropIndex("dbo.Department", new[] { "InstructorID" });
    DropIndex("dbo.OfficeAssignment", new[] { "InstructorID" });
    DropIndex("dbo.Enrollment", new[] { "StudentID" });
    DropIndex("dbo.CourseInstructor", new[] { "InstructorID" });
    RenameColumn(table: "dbo.Department", name: "InstructorID", newName: "PersonID");
    RenameColumn(table: "dbo.OfficeAssignment", name: "InstructorID", newName: "PersonID");
    RenameColumn(table: "dbo.Enrollment", name: "StudentID", newName: "PersonID");
    RenameColumn(table: "dbo.CourseInstructor", name: "InstructorID", newName: "PersonID");
    CreateTable(
        "dbo.Person",
        c => new
            {
                PersonID = c.Int(nullable: false, identity: true),
                LastName = c.String(maxLength: 50),
                FirstName = c.String(maxLength: 50),
                HireDate = c.DateTime(),
                EnrollmentDate = c.DateTime(),
                Discriminator = c.String(nullable: false, maxLength: 128),
                OldId = c.Int(nullable: false)
            })
        .PrimaryKey(t => t.PersonID);

    // Copy existing Student and Instructor data into new Person table.
    Sql("INSERT INTO dbo.Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator, OldId) SELECT LastName, FirstName, null AS HireDate, EnrollmentDate, 'Student' AS Discriminator, StudentId AS OldId FROM dbo.Student");
    Sql("INSERT INTO dbo.Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator, OldId) SELECT LastName, FirstName, HireDate, null AS EnrollmentDate, 'Instructor' AS Discriminator, InstructorId AS OldId FROM dbo.Instructor");

    // Fix up existing relationships to match new PK's.
    Sql("UPDATE dbo.Enrollment SET PersonId = (SELECT PersonId FROM dbo.Person WHERE OldId = Enrollment.PersonId AND Discriminator = 'Student')");
    Sql("UPDATE dbo.Department SET PersonId = (SELECT PersonId FROM dbo.Person WHERE OldId = Department.PersonId AND Discriminator = 'Instructor')");
    Sql("UPDATE dbo.OfficeAssignment SET PersonId = (SELECT PersonId FROM dbo.Person WHERE OldId = OfficeAssignment.PersonId AND Discriminator = 'Instructor')");
    Sql("UPDATE dbo.CourseInstructor SET PersonId = (SELECT PersonId FROM dbo.Person WHERE OldId = CourseInstructor.PersonId AND Discriminator = 'Instructor')");

    // Remove temporary key
    DropColumn("dbo.Person", "OldId");

    AddForeignKey("dbo.Department", "PersonID", "dbo.Person", "PersonID");
    AddForeignKey("dbo.OfficeAssignment", "PersonID", "dbo.Person", "PersonID");
    AddForeignKey("dbo.Enrollment", "PersonID", "dbo.Person", "PersonID", cascadeDelete: true);
    AddForeignKey("dbo.CourseInstructor", "PersonID", "dbo.Person", "PersonID", cascadeDelete: true);
    CreateIndex("dbo.Department", "PersonID");
    CreateIndex("dbo.OfficeAssignment", "PersonID");
    CreateIndex("dbo.Enrollment", "PersonID");
    CreateIndex("dbo.CourseInstructor", "PersonID");
    DropTable("dbo.Instructor");
    DropTable("dbo.Student");
}