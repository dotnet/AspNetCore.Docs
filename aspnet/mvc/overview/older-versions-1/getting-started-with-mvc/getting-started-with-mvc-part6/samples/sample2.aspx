<% using (Html.BeginForm()) {%>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Fields</legend>
       
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Id) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Id) %>
            <%: Html.ValidationMessageFor(model => model.Id) %>
        </div>
       
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Title) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Title) %>
            <%: Html.ValidationMessageFor(model => model.Title) %>
        </div>
       
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ReleaseDate) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.ReleaseDate) %>
            <%: Html.ValidationMessageFor(model => model.ReleaseDate) %>
        </div>
       
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Genre) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Genre) %>
            <%: Html.ValidationMessageFor(model => model.Genre) %>
        </div>
       
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Price) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Price) %>
            <%: Html.ValidationMessageFor(model => model.Price) %>
        </div>
       
        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>

<% } %>