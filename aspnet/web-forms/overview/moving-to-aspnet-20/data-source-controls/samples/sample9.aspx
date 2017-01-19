<asp:SqlDataSource ID="SqlDataSource1" runat="server"
    ConnectionString="<%$ConnectionStrings:Northwind%>"
    SelectCommand="SELECT * FROM Products"
    UpdateCommand="UPDATE Products SET ProductName=@ProductName WHERE ProductID=@ProductID">
      <UpdateParameters>
      <asp:ControlParameter Name="ProductName" 
        ControlID="txtProductName" PropertyName="Text" />
      <asp:ControlParameter Name="ProductID" 
        ControlID="ddlProducts" PropertyName="SelectedValue" />
</asp:SqlDataSource>