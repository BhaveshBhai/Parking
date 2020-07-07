using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarParkingApp.Controllers
{
    public class RateController : Controller
    {
        // GET: Rate
        public ActionResult Index()
        {
            return View();
        }
    }
}