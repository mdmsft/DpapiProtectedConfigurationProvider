using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;

namespace Fabrikam.Controllers
{
    [RoutePrefix("")]
    public class DefaultController : ApiController
    {
        [Route]
        public HttpResponseMessage Get()
        {
            var secret = ConfigurationManager.AppSettings["Secret"];

            var document = XDocument.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            var appSettingsElement = document.Root.Element("appSettings");
            var appSettingsXml = appSettingsElement.ToString(SaveOptions.None);
            var machineKeyElement = document.Root.Element("system.web").Element("machineKey");
            var machineKeyXml = machineKeyElement?.ToString(SaveOptions.None);

            var uptime = DateTime.Now.Subtract(Process.GetCurrentProcess().StartTime);

            var html = $@"
                <table>
                    <tbody>
                        <tr>
                            <td><b>Uptime</b></th>
                            <td>{uptime}</td>
                        </tr>
                        <tr>
                            <td><b>Secret (clear text)</b></th>
                            <td>{secret}</td>
                        </tr>
                        <tr>
                            <td><b>Secret (encrypted)</b></th>
                            <td>{HttpUtility.HtmlEncode(appSettingsXml)}</td>
                        </tr>
                        <tr>
                            <td><b>Machine key</b></th>
                            <td>{HttpUtility.HtmlEncode(machineKeyXml)}</td>
                        </tr>
                    </tbody>
                </table>";

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(html);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Text.Html);
            return response;
        }
    }
}
