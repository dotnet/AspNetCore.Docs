protected void Button1_Click(object sender, EventArgs e)
{

    System.Collections.ArrayList alist = 
        new System.Collections.ArrayList();
    int i;
    string arrayValue;
    for(i=0; i<5; i++)
    {
        arrayValue = "i = " + i.ToString();
        alist.Add(arrayValue);
    }
    for(i=0; i<alist.Count; i++)
    {
        Response.Write("<br />" + alist[i]);
    };
}