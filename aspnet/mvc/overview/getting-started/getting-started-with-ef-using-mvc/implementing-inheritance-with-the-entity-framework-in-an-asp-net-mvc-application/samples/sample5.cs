public override void Up()
{
    // Drop foreign keys and indexes that point to tables we're going to drop.
    DropForeignKey("dbo.Enrollment", "StudentID", "dbo.Student");
    DropIndex("dbo.Enrollment", new[] { "StudentID" });

    RenameTable(name: "dbo.Instructor", newName: "Person");
    AddColumn("dbo.Person", "EnrollmentDate", c => c.DateTime());
    AddColumn("dbo.Person", "Discriminator", c => c.String(nullable: false, maxLength: 128, defaultValue: "Instructor"));
    AlterColumn("dbo.Person", "HireDate", c => c.DateTime());
    AddColumn("dbo.Person", "OldId", c => c.Int(nullable: true));

    // Copy existing Student data into new Person table.
    Sql("INSERT INTO dbo.Person (LastName, FirstName, HireDate, EnrollmentDate, Discriminator, OldId) SELECT LastName, FirstName, null AS HireDate, EnrollmentDate, 'Student' AS Discriminator, ID AS OldId FROM dbo.Student");

    // Fix up existing relationships to match new PK's.
    Sql("UPDATE dbo.Enrollment SET StudentId = (SELECT ID FROM dbo.Person WHERE OldId = Enrollment.StudentId AND Discriminator = 'Student')");

    // Remove temporary key
    DropColumn("dbo.Person", "OldId");

    DropTable("dbo.Student");

    // Re-create foreign keys and indexes pointing to new table.
    AddForeignKey("dbo.Enrollment", "StudentID", "dbo.Person", "ID", cascadeDelete: true);
    CreateIndex("dbo.Enrollment", "StudentID");
}