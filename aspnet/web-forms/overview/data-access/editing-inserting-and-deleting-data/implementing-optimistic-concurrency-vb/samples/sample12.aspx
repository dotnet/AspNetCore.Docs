<asp:Label ID="DeleteConflictMessage" runat="server" Visible="False"
    EnableViewState="False" CssClass="Warning"
    Text="The record you attempted to delete has been modified by another user
           since you last visited this page. Your delete was cancelled to allow
           you to review the other user's changes and determine if you want to
           continue deleting this record." />
<asp:Label ID="UpdateConflictMessage" runat="server" Visible="False"
    EnableViewState="False" CssClass="Warning"
    Text="The record you attempted to update has been modified by another user
           since you started the update process. Your changes have been replaced
           with the current values. Please review the existing values and make
           any needed changes." />