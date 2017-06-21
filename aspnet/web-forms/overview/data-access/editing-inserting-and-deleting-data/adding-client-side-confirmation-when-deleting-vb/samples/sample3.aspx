<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False"
    CommandName="Delete" Text="Delete"
    OnClientClick="return confirm('Are you certain you want to delete this product?');">
</asp:LinkButton>