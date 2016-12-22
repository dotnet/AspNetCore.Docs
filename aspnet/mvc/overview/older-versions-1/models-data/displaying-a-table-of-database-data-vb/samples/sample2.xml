<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcApplication1.Movie))" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">

      Index

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

                Title

            </th>

            <th>

                Director

            </th>

            <th>

                DateReleased

            </th>

        </tr> 

    <% For Each item In Model%>

        <tr>

            <td>

                <%=Html.ActionLink("Edit", "Edit", New With {.id = item.Id})%> |

                <%=Html.ActionLink("Details", "Details", New With {.id = item.Id})%>

            </td>

            <td>

                <%= Html.Encode(item.Id) %>

            </td>

            <td>

                <%= Html.Encode(item.Title) %>

            </td>

            <td>

                <%= Html.Encode(item.Director) %>

            </td>

            <td>

                <%= Html.Encode(String.Format("{0:g}", item.DateReleased)) %>

            </td>

        </tr>

    <% Next%> 

    </table> 

</asp:Content>