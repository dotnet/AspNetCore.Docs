<p>
    <label for="Title">Dinner Title:</label>
    <%= Html.TextBox("Title", Model.Dinner.Title) %>
    <%=Html.ValidationMessage("Title", "*") %>
</p>

<p>
    <label for="Country">Country:</label>
    <%= Html.DropDownList("Country", Model.Countries) %>                
    <%=Html.ValidationMessage("Country", "*") %>
</p>