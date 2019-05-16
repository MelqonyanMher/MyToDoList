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
        private bool IsEnsureCreated = false;
        private IndexMeneger _indmen;

        public IActionResult Index()
        {
            if (!IsEnsureCreated)
            {
                using (var db = new TasksContext())
                {
                    db.Database.EnsureCreated();
                }
                IsEnsureCreated = true;
            }
            List<Itam> l;
            using (var db = new TasksContext())
            {
                l = db.Tasks.ToList();
            }
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
            using (var db = new TasksContext())
            {
                l = db.Tasks.Where(x => x.Compleated == true).ToList();
            }
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
            using (var db = new TasksContext())
            {
                l = db.Tasks.Where(x => x.Compleated == false).ToList();
            }

            _indmen = new IndexMeneger()
            {
                Itams = l,
                Title = " "
            };
            return View("Index", _indmen);
        }

        public IActionResult Checking(int id)
        {
            List<Itam> l;
            using (var db = new TasksContext())
            {
                Itam it = db.Tasks.SingleOrDefault(x => x.ItamId == id);

                if (it.Compleated)
                {
                    it.Compleated = false;
                }
                else
                {
                    it.Compleated = true;
                }

                db.Update(it);
                db.SaveChanges();

                l = db.Tasks.ToList();
            }

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
            using (var db = new TasksContext())
            {
                db.Tasks.Add(new Itam()
                {
                    Title = task.Title
                }
                );

                db.SaveChanges();

                l = db.Tasks.ToList();
            }


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
