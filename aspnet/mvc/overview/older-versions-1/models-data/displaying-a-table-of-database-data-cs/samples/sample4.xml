<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.Movie>>" %> 

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

    <% foreach (var item in Model) { %>

        <% Html.RenderPartial("MovieTemplate", item); %>

    <% } %> 

    </table> 

</asp:Content>