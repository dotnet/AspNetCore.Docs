<asp:DropDownList ID="DropDownAddCategory" runat="server" 
        ItemType="WingtipToys.Models.Category" 
        SelectMethod="GetCategories" DataTextField="CategoryName" 
        DataValueField="CategoryID" >
    </asp:DropDownList>