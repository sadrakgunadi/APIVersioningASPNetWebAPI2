using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIVersioningTest.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("1.5")]
    [Route("api/v{version:apiVersion}/home")]
    public class HomeController : ApiController
    {
        [HttpGet]
        public string Return1()
        {
            return "value1.0";
        }

        [HttpGet]
        [MapToApiVersion("1.5")]
        public string Return2()
        {
            return "value1.5";
        }


    }

    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/home")]
    public class Home2Controller : ApiController
    {
        [HttpGet]
        public string Return1()
        {
            return "value2.0";
        }
    }
}
