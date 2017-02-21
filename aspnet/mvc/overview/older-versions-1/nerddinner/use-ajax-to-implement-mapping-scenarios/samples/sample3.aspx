<%= Html.ValidationSummary() %>
 
<% using (Html.BeginForm()) { %>
 
    <fieldset>

        <div id="dinnerDiv">
            <p>
               [HTML Form Elements Removed for Brevity]
            </p>                 
            <p>
               <input type="submit" value="Save"/>
            </p>
        </div>
        
        <div id="mapDiv">    
            <%Html.RenderPartial("Map", Model.Dinner); %>
        </div> 
            
    </fieldset>

    <script type="text/javascript">

        $(document).ready(function() {
            $("#Address").blur(function(evt) {
                $("#Latitude").val("");
                $("#Longitude").val("");

                var address = jQuery.trim($("#Address").val());
                if (address.length < 1)
                    return;

                FindAddressOnMap(address);
            });
        });
    
    </script>

<% } %>