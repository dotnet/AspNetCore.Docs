public ActionResult Gallery()
{
    System.Threading.Thread.Sleep(1000);

    return this.File("~/App_Data/Photos.json", "application/json");
}