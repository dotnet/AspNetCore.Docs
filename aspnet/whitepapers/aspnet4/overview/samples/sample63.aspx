<asp:LinqDataSource ID="dataSource" runat="server" TableName="Products">
</asp:LinqDataSource>
<asp:QueryExtender TargetControlID="dataSource" runat="server">
   <asp:PropertyExpression>
      <asp:ControlParameter ControlID="CheckBoxDiscontinued" Name="Discontinued" />
   </asp:PropertyExpression>
</asp:QueryExtender>