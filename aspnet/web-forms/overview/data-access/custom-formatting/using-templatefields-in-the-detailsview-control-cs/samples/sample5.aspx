<asp:TemplateField HeaderText="Discontinued" SortExpression="Discontinued">
    <ItemTemplate>
        <%# DisplayDiscontinuedAsYESorNO((bool)
          Eval("Discontinued")) %>
    </ItemTemplate>
</asp:TemplateField>