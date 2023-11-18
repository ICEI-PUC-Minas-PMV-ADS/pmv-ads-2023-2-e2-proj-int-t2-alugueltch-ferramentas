using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly atdbContext _context;

        public async Task<IActionResult> Index()
        { 
            return View();
        }   
    }
}
