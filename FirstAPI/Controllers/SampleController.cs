using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        static string Name = string.Empty;
        [HttpGet]
        public string Get()
        {
            return Name;
        }

        [HttpPost]
        public string Post(string givenName)
        {
            Name=givenName;
            return $"Hello, {givenName}";
        }
    }
}
