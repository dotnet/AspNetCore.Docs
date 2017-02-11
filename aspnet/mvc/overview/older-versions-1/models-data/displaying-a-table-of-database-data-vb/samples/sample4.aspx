<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcApplication1.Movie))" %> 

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server"> 

    <h2>Index</h2>

    <table>

        <tr>

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

        <% Html.RenderPartial("MovieTemplate", item)%>

    <% Next%> 

    </table> 

</asp:Content>