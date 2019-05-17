using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasks.AspNetCore.Models;

namespace Tasks.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private IndexMeneger _indmen;
        private TasksContext _context;

        public HomeController(TasksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Itam> l;

            l = _context.Tasks.ToList();

            _indmen = new IndexMeneger()
            {
                Itams = l,
                Title = "Hovik"
            };
            return View(_indmen);
        }

        public IActionResult Compleated()
        {
            ViewData["Message"] = "Your application description page.";
            List<Itam> l;

            l = _context.Tasks.Where(x => x.Compleated == true).ToList();

            _indmen = new IndexMeneger()
            {
                Itams = l,
                Title = " "
            };
            return View("Index", _indmen);
        }
        public IActionResult UnCompleated()
        {
            ViewData["Message"] = "Your application description page.";
            List<Itam> l;

            l = _context.Tasks.Where(x => x.Compleated == false).ToList();

            _indmen = new IndexMeneger()
            {
                Itams = l,
                Title = " "
            };
            return View("Index", _indmen);
        }

        public IActionResult Checking(Guid id)
        {
            List<Itam> l;

            Itam it = _context.Tasks.SingleOrDefault(x => x.Id == id);

            if (it.Compleated)
            {
                it.Compleated = false;
            }
            else
            {
                it.Compleated = true;
            }

            _context.Update(it);
            _context.SaveChanges();

            l = _context.Tasks.ToList();


            _indmen = new IndexMeneger()
            {
                Itams = l,
                Title = " "
            };

            return View("Index", _indmen);
        }

        public IActionResult Add(IndexMeneger task)
        {
            List<Itam> l;

            _context.Tasks.Add(new Itam()
            {
                Title = task.Title
            }
            );

            _context.SaveChanges();

            l = _context.Tasks.ToList();



            _indmen = new IndexMeneger()
            {
                Itams = l,
                Title = " "
            };

            return View("Index", _indmen);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
