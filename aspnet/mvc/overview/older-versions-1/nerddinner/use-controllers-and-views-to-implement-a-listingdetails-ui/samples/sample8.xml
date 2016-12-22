<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            DinnerID:
            <%=Html.Encode(Model.DinnerID) %>
        </p>
        <p>
            Title:
            <%=Html.Encode(Model.Title) %>
        </p>
        <p>
            EventDate:
            <%= Html.Encode(String.Format("{0:g}", Model.EventDate)) %>
        </p>
        <p>
            Description:
            <%=Html.Encode(Model.Description) %>
        </p>
        <p>
            HostedBy:
            <%=Html.Encode(Model.HostedBy) %>
        </p>
        <p>
            ContactPhone:
            <%=Html.Encode(Model.ContactPhone) %>
        </p>
        <p>
            Address:
            <%=Html.Encode(Model.Address) %>
        </p>
        <p>
            Country:
            <%=Html.Encode(Model.Country) %>
        </p>
        <p>
            Latitude:
            <%= Html.Encode(String.Format("{0:F}",Model.Latitude)) %>
        </p>
        <p>
            Longitude:
            <%= Html.Encode(String.Format("{0:F}",Model.Longitude)) %>
        </p>
    </fieldset>
    
    <p>
        <%=Html.ActionLink("Edit","Edit", new { id=Model.DinnerID }) %>|
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>
    
</asp:Content>