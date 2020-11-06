using System.Web;
using System.Web.Http;

namespace Fabrikam
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(configuration => configuration.MapHttpAttributeRoutes());
        }
    }
}
