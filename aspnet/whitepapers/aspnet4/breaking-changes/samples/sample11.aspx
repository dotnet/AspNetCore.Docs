<asp:menu id="NavigationMenu"
    staticdisplaylevels="1"
    staticsubmenuindent="10" 
    orientation="Vertical" 
    target="_blank"  
    runat="server">
  <items>
    <asp:menuitem navigateurl="default2.aspx" 
        text="Home" 
        PopOutImageUrl="~/Images/Popout.gif"   
        tooltip="Home">
      <asp:menuitem navigateurl="default3.aspx"
          text="Movies"
          PopOutImageUrl="~/Images/Popout.gif"
          tooltip="Movies"> 
      </asp:menuitem>
    </asp:menuitem>
  </items>
</asp:menu>