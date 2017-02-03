<asp:LinqDataSource ID="dataSource" runat="server" TableName="Products"> 
</asp:LinqDataSource> 
<asp:QueryExtender TargetControlID="dataSource" runat="server"> 
  <asp:CustomExpression OnQuerying="FilterProducts" /> 
</asp:QueryExtender>