<div id="rsvpmsg">

<% if(Request.IsAuthenticated) { %>
 
    <% if(Model.IsUserRegistered(Context.User.Identity.Name)) { %>       

        <p>You are registred for this event!</p>

    <% } else { %>  
    
        <%= Ajax.ActionLink( "RSVP for this event",
                             "Register", "RSVP",
                             new { id=Model.DinnerID }, 
                             new AjaxOptions { UpdateTargetId="rsvpmsg"}) %>         
    <% } %>
    
<% } else { %>
 
    <a href="/Account/Logon">Logon</a> to RSVP for this event.

<% } %>
    
</div>