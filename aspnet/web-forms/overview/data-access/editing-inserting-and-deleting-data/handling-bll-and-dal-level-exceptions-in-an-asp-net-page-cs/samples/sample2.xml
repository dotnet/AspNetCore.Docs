protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
{
    if (e.NewValues["UnitPrice"] != null)
        e.NewValues["UnitPrice"] =decimal.Parse(e.NewValues["UnitPrice"].ToString(),
            System.Globalization.NumberStyles.Currency);
}