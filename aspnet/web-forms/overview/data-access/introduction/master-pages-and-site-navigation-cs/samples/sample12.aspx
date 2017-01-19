<%@ Control Language="CS" AutoEventWireup="true"
    CodeFile="SectionLevelTutorialListing.ascx.cs"
    Inherits="UserControls_SectionLevelTutorialListing" %>
<asp:Repeater ID="TutorialList" runat="server" EnableViewState="False">
    <HeaderTemplate><ul></HeaderTemplate>
    <ItemTemplate>
        <li><asp:HyperLink runat="server"
         NavigateUrl='<%# Eval("Url") %>'
         Text='<%# Eval("Title") %>'></asp:HyperLink>
                - <%# Eval("Description") %></li>
    </ItemTemplate>
    <FooterTemplate></ul></FooterTemplate>
</asp:Repeater>