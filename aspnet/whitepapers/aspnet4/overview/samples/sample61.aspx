<asp:LinqDataSource ID="dataSource" runat="server"> TableName="Products"> 
</asp:LinqDataSource> 
<asp:QueryExtender TargetControlID="dataSource" runat="server"> 
  <asp:SearchExpression DataFields="ProductName, Supplier.CompanyName" 
      SearchType="StartsWith"> 
    <asp:ControlParameter ControlID="TextBoxSearch" /> 
  </asp:SearchExpression> 
</asp:QueryExtender>