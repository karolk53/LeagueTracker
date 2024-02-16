using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueTracker.Data;
using Microsoft.AspNetCore.Mvc;

namespace LeagueTracker.Controllers
{
    public class LeagueController : Controller
    {
        private readonly DataContext _context;

        public LeagueController(DataContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var clubs = _context.Clubs.ToList();
            return View(clubs);
        }
    }
}