<asp:QueryExtender ID="SearchQueryExtender" runat="server" 
        TargetControlID="SearchEntityDataSource" >
        <asp:SearchExpression SearchType="StartsWith" DataFields="Title">
            <asp:ControlParameter ControlID="SearchTextBox" />
        </asp:SearchExpression>
        <asp:OrderByExpression DataField="Department.Name" Direction="Ascending">
            <asp:ThenBy DataField="Title" Direction="Ascending" />            
        </asp:OrderByExpression>
    </asp:QueryExtender>