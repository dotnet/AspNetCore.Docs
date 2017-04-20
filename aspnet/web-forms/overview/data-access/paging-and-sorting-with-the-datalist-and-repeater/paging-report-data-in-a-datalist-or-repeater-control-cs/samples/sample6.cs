private int PageIndex
{
    get
    {
        if (!string.IsNullOrEmpty(Request.QueryString["pageIndex"]))
            return Convert.ToInt32(Request.QueryString["pageIndex"]);
        else
            return 0;
    }
}
private int PageSize
{
    get
    {
        if (!string.IsNullOrEmpty(Request.QueryString["pageSize"]))
            return Convert.ToInt32(Request.QueryString["pageSize"]);
        else
            return 4;
    }
}
private int PageCount
{
    get
    {
        if (TotalRowCount <= 0 || PageSize <= 0)
            return 1;
        else
            return ((TotalRowCount + PageSize) - 1) / PageSize;
    }
}