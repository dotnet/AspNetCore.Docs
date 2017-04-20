<div class="editor-label">
    <%: Html.LabelFor(model => model.Rating) %>
</div>
<div class="editor-field">
    <%: Html.TextBoxFor(model => model.Rating)%>
    <%: Html.ValidationMessageFor(model => model.Rating)%>
</div>