using System;
using System.Threading.Tasks;
using System.Web.Http;
using Blogging.App_Start;
using Microsoft.Owin;
using Owin;
using Unity.AspNet.WebApi;

[assembly: OwinStartup(typeof(Blogging.Startup))]

namespace Blogging
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            HttpConfiguration config = new HttpConfiguration();
            var resolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
            config.DependencyResolver = resolver;

            app.UseWebApi(config);
        }
    }
}
