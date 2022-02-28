using Microsoft.AspNetCore.Mvc;
using PelatihanLanjutan.Services.BlogServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PelatihanLanjutan.Controllers
{
    public class LayerController : Controller
    {
        //private readonly IBlogServices;
        public IActionResult Index()
        {
            return View();
        }
    }
}
