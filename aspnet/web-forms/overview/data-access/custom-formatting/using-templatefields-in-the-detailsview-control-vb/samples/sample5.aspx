<asp:TemplateField HeaderText="Discontinued" SortExpression="Discontinued">
    <ItemTemplate>
        <%#DisplayDiscontinuedAsYESorNO(Convert.ToBoolean(Eval("Discontinued")))%> 
    </ItemTemplate>
</asp:TemplateField>