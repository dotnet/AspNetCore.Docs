@model Nullable<DateTime>

 @{
    DateTime dt = DateTime.Now;
    if (Model != null)
    {
       dt  = (System.DateTime) Model;
   
    }
    @Html.TextBox("", String.Format("{0:d}", dt.ToShortDateString()), new { @class = "datefield", type = "date"  })
}