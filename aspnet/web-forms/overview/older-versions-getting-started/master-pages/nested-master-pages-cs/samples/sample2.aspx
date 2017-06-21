<div id="topContent"> 
 <asp:HyperLink ID="lnkHome" runat="server" 
 NavigateUrl="~/NestedMasterPages/Default.aspx"
 Text="Nested Master Pages Tutorial (Simple)" /> 
</div> 
<div id="mainContent"> 
 <asp:ContentPlaceHolder id="MainContent" runat="server"> 
 </asp:ContentPlaceHolder>
</div>