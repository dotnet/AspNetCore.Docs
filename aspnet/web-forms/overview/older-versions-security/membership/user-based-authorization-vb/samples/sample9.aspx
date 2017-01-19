<asp:GridView ID="FilesGrid" DataKeyNames="FullName" runat="server" AutoGenerateColumns="False">
 <Columns>
 <asp:CommandField SelectText="View" ShowSelectButton="True"/>
 <asp:CommandField ShowDeleteButton="True" />
 <asp:BoundField DataField="Name" HeaderText="Name" />
 <asp:BoundField DataField="Length" DataFormatString="{0:N0}"
 HeaderText="Size in Bytes" HtmlEncode="False" />
 </Columns>
</asp:GridView>