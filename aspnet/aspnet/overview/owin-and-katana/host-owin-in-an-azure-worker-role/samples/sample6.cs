public override void OnStop()
{
    if (_app != null)
    {
        _app.Dispose();
    }
    base.OnStop();
}