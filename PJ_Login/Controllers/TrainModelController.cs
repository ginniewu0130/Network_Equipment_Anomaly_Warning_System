using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PJ_Login.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PJ_Login.Controllers
{
    public class TrainModelController : Controller
    {
        public IActionResult StartTrainModel()
        {
            return View();
        }
        
    }
}
    
