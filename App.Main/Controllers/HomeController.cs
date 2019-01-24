using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Main.Models;
using App.Main.Data;

namespace App.Main.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthRepository _repo;
        public HomeController(IAuthRepository repo)
        {
            _repo = repo;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Privacy(Value value)
        {
            var values = await _repo.GetValues();
            return View(values);
        }

        [HttpPost]
        public IActionResult AddValue(Value value)
        {
            _repo.Add(value);
            _repo.SaveAll();
            return View();
        }

        //public async Task<IActionResult> Login() => View();

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
