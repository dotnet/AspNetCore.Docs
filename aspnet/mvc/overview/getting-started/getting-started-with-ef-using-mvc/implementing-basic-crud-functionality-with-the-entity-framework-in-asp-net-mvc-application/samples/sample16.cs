protected override void Dispose(bool disposing)
{
    db.Dispose();
    base.Dispose(disposing);
}