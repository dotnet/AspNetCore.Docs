<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    Edit: <%=Html.Encode(Model.Title)%>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Dinner</h2>

    <%=Html.ValidationSummary("Please correct the errors and try again.") %>  
    
    <% using (Html.BeginForm()) { %>

        <fieldset>
            <p>
                <label for="Title">Dinner Title:</label>
                <%=Html.TextBox("Title") %>
                <%=Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="EventDate">EventDate:</label>
                <%=Html.TextBox("EventDate", String.Format("{0:g}", Model.EventDate))%>
                <%=Html.ValidationMessage("EventDate", "*") %>
            </p>
            <p>
                <label for="Description">Description:</label>
                <%=Html.TextArea("Description") %>
                <%=Html.ValidationMessage("Description", "*")%>
            </p>
            <p>
                <label for="Address">Address:</label>
                <%=Html.TextBox("Address") %>
                <%=Html.ValidationMessage("Address", "*") %>
            </p>
            <p>
                <label for="Country">Country:</label>
                <%=Html.TextBox("Country") %>               
                <%=Html.ValidationMessage("Country", "*") %>
            </p>
            <p>
                <label for="ContactPhone">ContactPhone #:</label>
                <%=Html.TextBox("ContactPhone") %>
                <%=Html.ValidationMessage("ContactPhone", "*") %>
            </p>
            <p>
                <label for="Latitude">Latitude:</label>
                <%=Html.TextBox("Latitude") %>
                <%=Html.ValidationMessage("Latitude", "*") %>
            </p>
            <p>
                <label for="Longitude">Longitude:</label>
                <%=Html.TextBox("Longitude") %>
                <%=Html.ValidationMessage("Longitude", "*") %>
            </p>
            <p>
                <input type="submit" value="Save"/>
            </p>
        </fieldset>
        
    <% } %>
    
</asp:Content>