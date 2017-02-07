@model MvcPWy.Models.IndexViewModel
@{
   ViewBag.Title = "Manage";
}
<h2>@ViewBag.Title.</h2>
<p class="text-success">@ViewBag.StatusMessage</p>
<div>
   <h4>Change your account settings</h4>
   <hr />
   <dl class="dl-horizontal">
      <dt>Password:</dt>
      <dd>
         [
         @if (Model.HasPassword)
         {
            @Html.ActionLink("Change your password", "ChangePassword")
         }
         else
         {
            @Html.ActionLink("Create", "SetPassword")
         }
         ]
      </dd>
      <dt>External Logins:</dt>
      <dd>
         @Model.Logins.Count [
         @Html.ActionLink("Manage", "ManageLogins") ]
      </dd>
        <dt>Phone Number:</dt>
      <dd>
         @(Model.PhoneNumber ?? "None") [
         @if (Model.PhoneNumber != null)
         {
            @Html.ActionLink("Change", "AddPhoneNumber")
            @: &nbsp;|&nbsp;
            @Html.ActionLink("Remove", "RemovePhoneNumber")
         }
         else
         {
            @Html.ActionLink("Add", "AddPhoneNumber")
         }
         ]
      </dd>
      <dt>Two-Factor Authentication:</dt> 
      <dd>
         @if (Model.TwoFactor)
         {
            using (Html.BeginForm("DisableTwoFactorAuthentication", "Manage", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
            {
               @Html.AntiForgeryToken()
               <text>Enabled
                  <input type="submit" value="Disable" class="btn btn-link" />
               </text>
            }
         }
         else
         {
            using (Html.BeginForm("EnableTwoFactorAuthentication", "Manage", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
            {
               @Html.AntiForgeryToken()
               <text>Disabled
                  <input type="submit" value="Enable" class="btn btn-link" />
               </text>
            }
         }
      </dd>
   </dl>
</div>