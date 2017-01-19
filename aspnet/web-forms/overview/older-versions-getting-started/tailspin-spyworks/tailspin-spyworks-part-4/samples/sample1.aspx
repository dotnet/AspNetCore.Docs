<asp:EntityDataSource ID="EDS_ProductsByCategory" runat="server"  
                      EnableFlattening="False" AutoGenerateWhereClause="True"
                      ConnectionString="name=CommerceEntities"  
                      DefaultContainerName="CommerceEntities" 
                      EntitySetName="Products">
<WhereParameters>
        <asp:QueryStringParameter Name="CategoryID" 
                                        QueryStringField="Category Id" 
                                        Type="Int32" />
       </WhereParameters>
</asp:EntityDataSource>