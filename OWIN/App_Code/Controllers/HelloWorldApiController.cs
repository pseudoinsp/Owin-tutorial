using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

/// <summary>
/// Summary description for HelloWorldApiController
/// </summary>
[RoutePrefix("api")]
public class HelloWorldApiController : ApiController
{
    [Route("hello")]   
    [HttpGet]
    public IHttpActionResult HelloWorld()
    {
        return Content(System.Net.HttpStatusCode.OK, "Hello from Web Api");
    }
}