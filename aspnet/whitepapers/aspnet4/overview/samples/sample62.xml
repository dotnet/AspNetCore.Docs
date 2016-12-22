<asp:LinqDataSource ID="dataSource" runat="server"> TableName="Products"> 
</asp:LinqDataSource> 
<asp:QueryExtender TargetControlID="dataSource" runat="server"> 
  <asp:RangeExpression DataField="UnitPrice" MinType="Inclusive" 
      MaxType="Inclusive"> 
    <asp:ControlParameter ControlID="TextBoxFrom" /> 
    <asp:ControlParameter ControlID="TexBoxTo" /> 
  </asp:RangeExpression> 

</asp:QueryExtender>