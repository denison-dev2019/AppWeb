using AppWeb.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.Areas.Adm.Controller
{
    [Area("admin")]
    [Route("admin")]
    public class adminController : CustomController
    {
        public adminController(IServiceProvider serviceProvider): base(serviceProvider)
        {
                
        }
        public ActionResult Index()
        {
            return View("~/Areas/Admin/Views/Index.cshtml");
        }

        
    }
}
