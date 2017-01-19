<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Movies.Models.Movie>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Movie List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>My Movie List</h2>
    <table>
        <tr>
            <th>Title</th>
            <th>ReleaseDate</th>
            <th>Genre</th>
            <th>Rating</th>
            <th>Price</th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td><%: item.Title %></td>
            <td><%: String.Format("{0:g}", item.ReleaseDate) %></td>
            <td><%: item.Genre %></td>
            <td><%: item.Rating %></td>
            <td><%: String.Format("{0:F}", item.Price) %></td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>
</asp:Content>