<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    Delete Confirmation:  <%=Html.Encode(Model.Title) %>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        Delete Confirmation
    </h2>

    <div>
        <p>Please confirm you want to cancel the dinner titled: 
           <i> <%=Html.Encode(Model.Title) %>? </i> 
        </p>
    </div>
    
    <% using (Html.BeginForm()) {  %>
        <input name="confirmButton" type="submit" value="Delete" />        
    <% } %>
     
</asp:Content>