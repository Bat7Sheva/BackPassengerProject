using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class Tofes : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public Tofes(IMemoryCache memoryCache) =>
            _memoryCache = memoryCache;

        [HttpPost]
        public bool Save([FromBody] List<Iform> element)
        {
            try
            {
                _memoryCache.Set("Passenger", element);
                //var Getcachedata = _memoryCache.Get("Passenger");
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}