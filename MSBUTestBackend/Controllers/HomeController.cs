using Microsoft.AspNetCore.Mvc;
using MSBUTestBackend.Helper;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MSBUTestBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration configuration)
        {
            Configuration= configuration;
        }
        [HttpGet]
        public string GetLocation()
        {
            string Result = new Repository(Configuration).GetLocation();
            return Result;
        }

        [HttpPost]
        public string InsertStorageLocation(TrBpkbObjectRequest objReq)
        {
            string Result = new Repository(Configuration).SaveTrBpkb(objReq);
            return Result;
        }
    }
}
