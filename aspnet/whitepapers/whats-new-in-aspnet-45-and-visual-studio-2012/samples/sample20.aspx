<asp:FormView runat="server" ID="editCustomer">
<EditItemTemplate>
 	   <div>
 		   <asp:Label runat="server" AssociatedControlID="firstName">
 			   First Name:</asp:Label>
 		   <asp:TextBox ID="firstName" runat="server"
 			   Text='<%#Bind("FirstName") %>' />
 	   </div>
 	   <div>
 		   <asp:Label runat="server" AssociatedControlID="lastName">
 			   First Name:</asp:Label>
 		   <asp:TextBox ID="lastName" runat="server"
 			   Text='<%#
Bind("LastName") %>' />
 	   </div>
 	   <asp:Button runat="server" CommandName="Update"/>
</EditItemTemplate>
</asp:FormView>