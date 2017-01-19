<asp:SqlDataSource ID="sds" runat="server" ConnectionString="Data
 Source=(local)\SQLEXPRESS;Initial Catalog=Tutorials;Integrated Security=True"
 ProviderName="System.Data.SqlClient" OldValuesParameterFormatString="original_{0}"
 SelectCommand="SELECT [id], [char], [description], [position] FROM [AJAX] ORDER BY [position]"
 UpdateCommand="UPDATE [AJAX] SET position=@position WHERE [id]=@original_id">
 <UpdateParameters>
 <asp:Parameter Name="position" Type="Int32" />
 <asp:Parameter Name="original_id" Type="Int32" />
 </UpdateParameters>
</asp:SqlDataSource>