using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationWebAPI1.Areas.MyArea.Controllers
{
    public class MyAreaMainController : ApiController
    {
        [HttpGet]
        [ActionName("Get")]
        public string Get()
        {
            return "hey, my area here.";
        }
        [HttpGet]
        [ActionName("GetTheList")]
        public string GetTheList()
        {
            var someList = new List<string> {"first item", "second item"}.ToList();
            return String.Join(", ", someList.ToArray());
        }

        [HttpGet]
        [ActionName("GetSomeValue")]
        public string GetSomeValue()
        {
            return "some value here";
        }
    }
}
