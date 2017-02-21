<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Upcoming Dinners</h2>

    <ul>
        <% foreach (var dinner in Model) { %>
        
            <li>                 
                <%=Html.Encode(dinner.Title) %>            
                on 
                <%=Html.Encode(dinner.EventDate.ToShortDateString())%>
                @
                <%=Html.Encode(dinner.EventDate.ToShortTimeString())%>
            </li>
            
        <% } %>
    </ul>
    
</asp:Content>