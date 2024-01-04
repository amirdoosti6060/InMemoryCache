using InMemoryCache.Models;
using InMemoryCache.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InMemoryCache.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CachingService _cachingService;

        public HomeController(ILogger<HomeController> logger, CachingService cachingService)
        {
            _logger = logger;
            _cachingService = cachingService;
        }

        public IActionResult Index()
        {
            // Use the caching service to get or set cached data
            var cachedData = _cachingService.GetOrSetCachedData();

            return View(model: cachedData);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
