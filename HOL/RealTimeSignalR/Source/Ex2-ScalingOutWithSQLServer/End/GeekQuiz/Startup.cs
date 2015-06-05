using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeekQuiz.Startup))]

namespace GeekQuiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var sqlConnectionString = @"Server=(localdb)\v11.0;Database=<YOUR_SIGNALR_DATABASE>;Integrated Security=True;";
            GlobalHost.DependencyResolver.UseSqlServer(sqlConnectionString);            
            this.ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
