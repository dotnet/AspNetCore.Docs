public ActionResult RemoveAccountList()
{
    var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId<int>());
    ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
    return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
}