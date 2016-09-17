using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BTJ.PowerApps.WebApp.Startup))]
namespace BTJ.PowerApps.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
