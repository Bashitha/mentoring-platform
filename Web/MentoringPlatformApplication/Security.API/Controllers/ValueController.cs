using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Security.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Value")]
    public class ValueController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Test";
        }
    }
}