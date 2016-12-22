<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MvcApplication1.Views.Home.Index" %>
<%@ Import Namespace="MvcApplication1.Models" %>
<%@ Import Namespace="MvcApplication1.Helpers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body>
    <div>

    <% Response.WriteSubstitution(News.RenderNews); %>
    
    <hr />
    
    <% Html.RenderBanner(); %>
    
    <hr />
    
    The content of this page is output cached.
    <%= DateTime.Now %>

    </div>
</body>
</html>