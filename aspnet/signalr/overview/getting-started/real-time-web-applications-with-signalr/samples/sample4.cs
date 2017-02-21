public void Configuration(IAppBuilder app)
{
    this.ConfigureAuth(app);
    app.MapSignalR();
}