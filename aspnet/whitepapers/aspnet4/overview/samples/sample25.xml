<form id="form1" runat="server"> 
  <script runat="server"> 
      protected override void OnLoad(EventArgs e) { 
      if (!IsPostBack) { 
        label1.Text = label2.Text = "[DynamicValue]"; 
      } 
      base.OnLoad(e); 
    } 
  </script> 
  <asp:PlaceHolder ID="PlaceHolder1" runat="server" ViewStateMode="Disabled"> 
      Disabled: <asp:Label ID="label1" runat="server" Text="[DeclaredValue]" /><br /> 
    <asp:PlaceHolder ID="PlaceHolder2" runat="server" ViewStateMode="Enabled"> 
        Enabled: <asp:Label ID="label2" runat="server" Text="[DeclaredValue]" /> 
    </asp:PlaceHolder> 
  </asp:PlaceHolder> 
  <hr /> 
  <asp:button ID="Button1" runat="server" Text="Postback" /> 
  <%-- Further markup here --%>