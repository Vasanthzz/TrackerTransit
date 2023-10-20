//////////////////////using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using test.lib.Entity;
using test.lib.Service;
using test.web.Models;

namespace test.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly testservice _testservice;

        public HomeController(ILogger<HomeController> logger, testservice testservice)
        {
            _logger = logger;
            _testservice = testservice;
        }
        public IActionResult Index()
        {
            ViewBag.Control = _testservice.GetControls();
            return View();
        }
        [HttpPost]
        public IActionResult Index(string type)
        {
            if (type == "Driver"){
                return RedirectToAction("DriverRegister");
            }
            else if(type == "User")
            {
                return RedirectToAction("UserRegister");
            }
            else
            {
                return View();
            }
        }
        public IActionResult DriverRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DriverRegisterAsync(Driver driver)
        {
            var result = await _testservice.AddDriverAsync(driver);
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Location()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetLocation(string latitude, string longitude)
        {

            var locationData = new { Latitude = latitude, Longitude = longitude };
            return Json(locationData);
        }

        [HttpGet]
        public JsonResult GetOtherUserLocations()
        {
            // Query the database to retrieve locations of other users
            var otherUserLocations = _testservice.GetOtherLocation();

            return Json(otherUserLocations);
        }

        public class LocationData
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}