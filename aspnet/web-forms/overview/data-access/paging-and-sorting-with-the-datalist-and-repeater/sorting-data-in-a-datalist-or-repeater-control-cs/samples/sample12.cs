private int StartRowIndex
{
    get
    {
        object o = ViewState["StartRowIndex"];
        if (o == null)
            return 0;
        else
            return (int)o;
    }
    set
    {
        ViewState["StartRowIndex"] = value;
    }
}
private int MaximumRows
{
    get
    {
        object o = ViewState["MaximumRows"];
        if (o == null)
            return 5;
        else
            return (int)o;
    }
    set
    {
        ViewState["MaximumRows"] = value;
    }
}