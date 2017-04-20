<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable(Of ContactManager.Contact))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Index</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                FirstName
            </th>
            <th>
                LastName
            </th>
            <th>
                Phone
            </th>
            <th>
                Email
            </th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.Id})%> |
                <%=Html.ActionLink("Details", "Details", New With {.id = item.Id})%>
            </td>
            <td>
                <%=Html.Encode(item.Id)%>
            </td>
            <td>
                <%=Html.Encode(item.FirstName)%>
            </td>
            <td>
                <%=Html.Encode(item.LastName)%>
            </td>
            <td>
                <%=Html.Encode(item.Phone)%>
            </td>
            <td>
                <%=Html.Encode(item.Email)%>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>