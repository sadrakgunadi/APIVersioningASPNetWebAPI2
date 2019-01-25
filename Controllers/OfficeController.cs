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
    [RoutePrefix("api/office")]
    public class OfficeController : ApiController
    {
        [HttpGet]
        public string Return1()
        {
            return "Office Return 1.0";
        }

        [HttpGet]
        [MapToApiVersion("1.5")]
        public string Return2()
        {
            return "Office Return 1.5";
        }
    }

    [ApiVersion("2.0")]
    [RoutePrefix("api/office")]
    public class Office2Controller : ApiController
    {
        [HttpGet]
        public string Return1()
        {
            return "Office Return 2.0";
        }
    }
}
