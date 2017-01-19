<asp:UpdatePanel ID="ProductPanel" runat="server" onload="ProductPanel_Load">
 <ContentTemplate>
 ...

 <asp:Timer ID="ProductTimer" runat="server" Interval="15000">
 </asp:Timer>
 </ContentTemplate>
</asp:UpdatePanel>