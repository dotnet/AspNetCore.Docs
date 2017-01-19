<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of MvcApplication1.Movie)" %>

<tr>

    <td>

        <%= Html.Encode(Model.Id) %>

    </td>

    <td>

        <%= Html.Encode(Model.Title) %>

    </td>

    <td>

        <%= Html.Encode(Model.Director) %>

    </td>

    <td>

        <%= Html.Encode(String.Format("{0:g}", Model.DateReleased)) %>

    </td>

</tr>