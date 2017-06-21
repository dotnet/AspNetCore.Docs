<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of ContactManager.Contact)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Delete</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>
    
    <p>
    Are you sure that you want to delete the entry for
    <%= Model.FirstName %> <%= Model.LastName %>?
    </p>

    <% Using Html.BeginForm(New With { .Id = Model.Id }) %>
       <p> 
            <input type="submit" value="Delete" />
        </p>
    <% End Using %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>