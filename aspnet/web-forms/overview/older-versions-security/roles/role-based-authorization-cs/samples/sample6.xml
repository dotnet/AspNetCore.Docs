protected void Page_Load(object sender, EventArgs e)    
{    
     if (!Page.IsPostBack)    
          BindUserGrid();    
}

private void BindUserGrid()    
{    
     MembershipUserCollection allUsers = Membership.GetAllUsers();    
     UserGrid.DataSource = allUsers;    
     UserGrid.DataBind();    
}