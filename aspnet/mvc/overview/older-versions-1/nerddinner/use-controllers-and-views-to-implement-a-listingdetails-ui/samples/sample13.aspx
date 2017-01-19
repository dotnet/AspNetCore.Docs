<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    Upcoming Dinners
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Upcoming Dinners</h2>

    <ul>
        <% foreach (var dinner in Model) { %>
        
            <li>     
                <%=Html.ActionLink(dinner.Title, "Details", new { id=dinner.DinnerID }) %>
                on 
                <%=Html.Encode(dinner.EventDate.ToShortDateString())%>
                @
                <%=Html.Encode(dinner.EventDate.ToShortTimeString())%>
            </li>
            
        <% } %>
    </ul>
</asp:Content>