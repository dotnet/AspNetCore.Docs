protected void NewCategory_ItemInserted
    (object sender, DetailsViewInsertedEventArgs e)
{
    if (e.Exception != null)
    {
        // Need to delete brochure file, if it exists
        if (e.Values["brochurePath"] != null)
            System.IO.File.Delete(Server.MapPath(
                e.Values["brochurePath"].ToString()));
    }
}