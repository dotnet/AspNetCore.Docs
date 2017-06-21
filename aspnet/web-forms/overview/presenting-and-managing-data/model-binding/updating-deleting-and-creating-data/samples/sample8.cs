public void addStudentForm_InsertItem()
{
    var item = new Student();
            
    TryUpdateModel(item);
    if (ModelState.IsValid)
    {
        using (SchoolContext db = new SchoolContext())
        {
            db.Students.Add(item);
            db.SaveChanges();
        }
    }
}

protected void cancelButton_Click(object sender, EventArgs e)
{
    Response.Redirect("~/Students");
}

protected void addStudentForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
{
    Response.Redirect("~/Students");
}