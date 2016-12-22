public class Startup 
{   
    public void Configuration(IAppBuilder app) 
    {           
        var sqlConnectionString = @"Server=(localdb)\v11.0;Database=<YOUR-DATABASE>;Integrated Security=True;";
        GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString); 
        this.ConfigureAuth(app);
        app.MapSignalR();
    }
}