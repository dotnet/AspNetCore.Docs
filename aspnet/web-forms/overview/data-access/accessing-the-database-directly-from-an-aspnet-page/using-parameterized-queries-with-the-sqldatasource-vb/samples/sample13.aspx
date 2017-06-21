<asp:SqlDataSource ID="ProductsByCategoryDataSource" runat="server"
    ConnectionString="<%$ ConnectionStrings:NORTHWNDConnectionString %>"
    SelectCommand="GetProductsByCategory" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:Parameter Name="CategoryID" Type="Int32" />
    </SelectParameters>
</asp:SqlDataSource>