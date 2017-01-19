<asp:FormView runat="server" ID="FormView1" 
    DataSourceID="DetailsDataSource" 
    OnItemDeleted="FormView1_ItemDeleted"> 
  <ItemTemplate> 
    <table class="DDDetailsTable" cellpadding="6"> 
      <asp:DynamicEntity runat="server" /> 
      <tr class="td"> 
        <td colspan="2"> 
          <asp:DynamicHyperLink ID="EditHyperLink" runat="server" 
              Action="Edit" Text="Edit" /> 
          <asp:LinkButton ID="DeleteLinkButton" runat="server" 
              CommandName="Delete" 
              CausesValidation="false" 
              OnClientClick='return confirm("Are you sure you want to delete this item?");' 
              Text="Delete" /> 
        </td> 
      </tr> 
    </table> 
  </ItemTemplate> 

</asp:FormView>