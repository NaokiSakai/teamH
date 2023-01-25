using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace TeamHApp.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Upload()
        {
            IFormFile? file= Request.Form.Files["uploadFile"];

            if (file != null)
            {

            }
            /*if (uploadFile != null)
            {
                uploadFile.SaveAs(@"c:\upload-file\" + Path.GetFileName(uploadFile.FileName));
            }:*/
            return View();
        }
    }
}