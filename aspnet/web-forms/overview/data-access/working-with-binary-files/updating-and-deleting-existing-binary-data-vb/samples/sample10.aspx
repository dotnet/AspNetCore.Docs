<asp:TemplateField>
    <EditItemTemplate>
        <asp:TextBox ID="TextBox1" runat="server" 
            Text='<%# Eval("CategoryID") %>'></asp:TextBox>
    </EditItemTemplate>
    <ItemTemplate>
        <asp:Image ID="Image1" runat="server" 
            ImageUrl='<%# Eval("CategoryID", 
                "DisplayCategoryPicture.aspx?CategoryID={0}") %>' />
    </ItemTemplate>
</asp:TemplateField>