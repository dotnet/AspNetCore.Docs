<ul>
<asp:Repeater runat="server" ID="customers">
 	   <ItemTemplate>
 		   <li>
 			   First Name: <%# Eval("FirstName")%><br />
 			   Last Name: <%# Eval("LastName")%><br />
 		   </li>
 	   </ItemTemplate>
</asp:Repeater>
</ul>