protected void Page_Load(object sender, EventArgs e)
{
    // Get the data from the SqlDataSource as a DataView
    DataView randomCategoryView =
        (DataView)RandomCategoryDataSource.Select(DataSourceSelectArguments.Empty);
    if (randomCategoryView.Count > 0)
    {
        // Assign the CategoryName value to the Label
        CategoryNameLabel.Text =
            string.Format("Here are Products in the {0} Category...",
                randomCategoryView[0]["CategoryName"].ToString());
    }
}