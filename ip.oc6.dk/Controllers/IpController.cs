using ip.oc6.dk.Models;
using Microsoft.AspNetCore.Mvc;

namespace ip.oc6.dk.Controllers
{
    [Route("")]
    [ApiController]
    public sealed class IpController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IpResponse Index()
        {
            return new IpResponse
            {
                Ip = HttpContext.Connection.RemoteIpAddress.ToString()
            };
        }
    }
}
