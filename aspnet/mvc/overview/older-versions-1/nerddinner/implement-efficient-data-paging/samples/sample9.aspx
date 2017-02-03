<% if (Model.HasPreviousPage) { %>

    <%= Html.RouteLink("<<<", "UpcomingDinners", new { page = (Model.PageIndex-1) }) %>

<% } %>

<% if (Model.HasNextPage) {  %>

    <%= Html.RouteLink(">>>", "UpcomingDinners", new { page = (Model.PageIndex + 1) }) %>

<% } %>