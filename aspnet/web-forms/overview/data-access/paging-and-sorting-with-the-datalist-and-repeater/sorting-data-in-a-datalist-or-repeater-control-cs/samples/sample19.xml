private string SortExpression
{
    get
    {
        object o = ViewState["SortExpression"];
        if (o == null)
            return "ProductName";
        else
            return o.ToString();
    }
    set
    {
        ViewState["SortExpression"] = value;
    }
}