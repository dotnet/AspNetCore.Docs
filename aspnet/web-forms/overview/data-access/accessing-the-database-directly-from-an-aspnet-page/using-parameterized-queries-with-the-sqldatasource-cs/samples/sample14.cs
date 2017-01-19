// Assign the ProductsByCategoryDataSource's
// CategoryID parameter's DefaultValue property
ProductsByCategoryDataSource.SelectParameters["CategoryID"].DefaultValue =
    randomCategoryView[0]["CategoryID"].ToString();