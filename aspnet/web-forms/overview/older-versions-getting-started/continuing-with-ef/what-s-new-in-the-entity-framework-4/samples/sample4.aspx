<h2>Update Credits</h2>
    Enter the number to multiply the current number of credits by: 
    <asp:TextBox ID="CreditsMultiplierTextBox" runat="server"></asp:TextBox>
    <br /><br />
    <asp:Button ID="ExecuteButton" runat="server" Text="Execute" OnClick="ExecuteButton_Click" /><br /><br />
    Rows affected:
    <asp:Label ID="RowsAffectedLabel" runat="server" Text="0" ViewStateMode="Disabled"></asp:Label><br /><br />