<asp:menu id="NavigationMenu"
    staticdisplaylevels="1"
    staticsubmenuindent="10" 
    orientation="Vertical" 
    target="_blank" 
    StaticPopOutImageTextFormatString="More..."
    StaticPopOutImageUrl="Images/Popout.gif"   
    runat="server">
  <items>
    <asp:menuitem navigateurl="default2.aspx" 
        text="Home" 
        tooltip="Home">
      <asp:menuitem navigateurl="default3.aspx"
          text="Movies"
          tooltip="Movies"> 
      </asp:menuitem>
    </asp:menuitem>
  </items>
</asp:menu>