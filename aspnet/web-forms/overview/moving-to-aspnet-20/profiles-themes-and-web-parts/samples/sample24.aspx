<%@ Control Language="C#" ClassName="DisplayModeMenuCS" %>

<script runat="server">

    // Use a field to reference the current WebPartManager control.
    WebPartManager _manager;
    void Page_Init(object sender, EventArgs e) {
        Page.InitComplete += new EventHandler(InitComplete);
    }
    void InitComplete(object sender, System.EventArgs e) {
        _manager = WebPartManager.GetCurrentWebPartManager(Page);
        String browseModeName = WebPartManager.BrowseDisplayMode.Name;
        // Fill the drop-down list with the names of supported display modes.
        foreach (WebPartDisplayMode mode in
        _manager.SupportedDisplayModes) {
            String modeName = mode.Name;
            // Make sure a mode is enabled before adding it.
            if (mode.IsEnabled(_manager)) {
                ListItem item = new ListItem(modeName, modeName);
                DisplayModeDropdown.Items.Add(item);
            }
        }
        // If Shared scope is allowed for this user, display the
        // scope-switching UI and select the appropriate radio
        // button for the current user scope.
        if (_manager.Personalization.CanEnterSharedScope) {
            Panel2.Visible = true;
            if (_manager.Personalization.Scope ==
            PersonalizationScope.User)
                RadioButton1.Checked = true;
            else
                RadioButton2.Checked = true;
        }
    }

    // Change the page to the selected display mode.
    void DisplayModeDropdown_SelectedIndexChanged(object sender,
        EventArgs e) {
        String selectedMode = DisplayModeDropdown.SelectedValue;
        WebPartDisplayMode mode =
            _manager.SupportedDisplayModes[selectedMode];
        if (mode != null)
            _manager.DisplayMode = mode;
    }
    // Set the selected item equal to the current display mode.
    void Page_PreRender(object sender, EventArgs e) {
        ListItemCollection items = DisplayModeDropdown.Items;
        int selectedIndex =
        items.IndexOf(items.FindByText(_manager.DisplayMode.Name));
        DisplayModeDropdown.SelectedIndex = selectedIndex;
    }
    // Reset all of a user's personalization data for the page.
    protected void LinkButton1_Click(object sender, EventArgs e) {
        _manager.Personalization.ResetPersonalizationState();
    }
    // If not in User personalization scope, toggle into it.
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e) {
        if (_manager.Personalization.Scope == PersonalizationScope.Shared)
            _manager.Personalization.ToggleScope();
    }

    // If not in Shared scope, and if user has permission, toggle
    // the scope.
    protected void RadioButton2_CheckedChanged(object sender,
    EventArgs e) {
        if (_manager.Personalization.CanEnterSharedScope &&
            _manager.Personalization.Scope == PersonalizationScope.User)
            _manager.Personalization.ToggleScope();
    }
</script>

<div>
    <asp:Panel ID="Panel1" runat="server"
      BorderWidth="1" Width="230" BackColor="lightgray"
        Font-Names="Verdana, Arial, Sans Serif">
        <asp:Label ID="Label1" runat="server"
          Text=" Display Mode" Font-Bold="true"
            Font-Size="8" Width="120" />
        <asp:DropDownList ID="DisplayModeDropdown"
          runat="server" AutoPostBack="true" Width="120"
            OnSelectedIndexChanged="DisplayModeDropdown_SelectedIndexChanged" />
        <asp:LinkButton ID="LinkButton1" runat="server"
             Text="Reset User State"
             ToolTip="Reset the current user's personalization data for the page."
             Font-Size="8" OnClick="LinkButton1_Click" />
        <asp:Panel ID="Panel2" runat="server"
            GroupingText="Personalization Scope" Font-Bold="true"
            Font-Size="8" Visible="false">
            <asp:RadioButton ID="RadioButton1" runat="server"
                Text="User" AutoPostBack="true"
                GroupName="Scope"
                OnCheckedChanged="RadioButton1_CheckedChanged" />
            <asp:RadioButton ID="RadioButton2" runat="server"
                Text="Shared" AutoPostBack="true"
                GroupName="Scope"
                OnCheckedChanged="RadioButton2_CheckedChanged" />
        </asp:Panel>
    </asp:Panel>
</div>