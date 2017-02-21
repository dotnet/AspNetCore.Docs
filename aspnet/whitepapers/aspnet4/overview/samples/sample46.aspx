<asp:sqldatasource id="SqlDataSource1" runat="server" 
    connectionstring="<%$ ConnectionStrings:MyNorthwind %>" 
    selectcommand="SELECT CompanyName,ShipperID FROM Shippers where 
      CompanyName=@companyname" 
  <selectparameters> 
    <asp:routeparameter name="companyname" RouteKey="searchterm" /> 
  </selectparameters> 

</asp:sqldatasource>