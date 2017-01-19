<asp:SqlDataSource ID="sds" runat="server" ConnectionString="Data
 Source=(local)\SQLEXPRESS;Initial Catalog=AdventureWorks;Integrated Security=True"
 DeleteCommand="DELETE FROM [Purchasing].[Vendor] WHERE [VendorID] = @VendorID"
 InsertCommand="INSERT INTO [Purchasing].[Vendor] ([Name]) VALUES (@Name)"
 ProviderName="System.Data.SqlClient"
 SelectCommand="SELECT [VendorID], [Name] FROM [Purchasing].[Vendor]"
 UpdateCommand="UPDATE [Purchasing].[Vendor] SET [Name] = @Name WHERE [VendorID] = @VendorID">
 <DeleteParameters>
 <asp:Parameter Name="VendorID" Type="Int32" />
 </DeleteParameters>
 <UpdateParameters>
 <asp:Parameter Name="Name" Type="String" />
 <asp:Parameter Name="VendorID" Type="Int32" />
 </UpdateParameters>
 <InsertParameters>
 <asp:Parameter Name="Name" Type="String" />
 </InsertParameters>
</asp:SqlDataSource>