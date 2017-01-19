<asp:TemplateField HeaderText="Brochure">
    <ItemTemplate>
        <%# GenerateBrochureLink(Eval("BrochurePath")) %>
    </ItemTemplate>
</asp:TemplateField>