using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarParkingApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarParkingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrateController : ControllerBase
    {
        CalculateRate CR = new CalculateRate();
       
        [Route("CalculateRate")]

        public async Task<IActionResult> CalculateRate(DateTime startTime, DateTime endTime)
        {
            return Ok(CR.RateCalculate(startTime, endTime));
        }
    }
}