<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"> 
<html xmlns="http://www.w3.org/1999/xhtml"> 
<head id="Head1" runat="server"> 
 <title>Untitled Page</title>
 <asp:ContentPlaceHolder id="head" runat="server">
 </asp:ContentPlaceHolder> 
 <link href="AlternateStyles.css" rel="stylesheet" type="text/css" /> 
</head> 
<body> 
 <form id="form1" runat="server"> 
 <asp:ScriptManager ID="MyManager" runat="server"> 
 </asp:ScriptManager>
 <div id="topContent">
 <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Default.aspx" 
 Text="Master Pages Tutorials" /> 
 </div>
 <div id="navContent">
 <asp:ListView ID="LessonsList" runat="server" 
 DataSourceID="LessonsDataSource">
 <LayoutTemplate>
 <asp:PlaceHolder runat="server" ID="itemPlaceholder" /> 
 </LayoutTemplate>
 <ItemTemplate>
 <asp:HyperLink runat="server" ID="lnkLesson" 
 NavigateUrl='<%# Eval("Url") %>' 
 Text='<%# Eval("Title") %>' /> 
 </ItemTemplate>
 <ItemSeparatorTemplate> | </ItemSeparatorTemplate> 
 </asp:ListView>
 <asp:SiteMapDataSource ID="LessonsDataSource" runat="server" 
 ShowStartingNode="false" /> 
 </div>
 <div id="mainContent">
 <asp:ContentPlaceHolder id="MainContent" runat="server"> 
 </asp:ContentPlaceHolder>
 </div> 
 <div id="footerContent">
 <p> 
 <asp:Label ID="DateDisplay" runat="server"></asp:Label> 
 </p>
 <asp:ContentPlaceHolder ID="QuickLoginUI" runat="server"> 
 </asp:ContentPlaceHolder>
 <asp:ContentPlaceHolder ID="LeftColumnContent" runat="server"> 
 </asp:ContentPlaceHolder>
 </div> 
 </form>
</body> 
</html>