using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tasks.AspNetCore.Models;
using Tasks.AspNetCore.Services;

namespace Tasks.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        IToDoService _toDo;

        public HomeController(IToDoService todo)
        {
            _toDo = todo;
        }
        IndexMeneger _indmen;
        public IActionResult Index()
        {


             _indmen = new IndexMeneger()
            {
                Itams = _toDo.GetItams(),
                Title=string.Empty
            };
            return View(_indmen);
        }

        public IActionResult Compleated()
        {
            ViewData["Message"] = "Your application description page.";
           
            _indmen = new IndexMeneger()
            {
                Itams = _toDo.GetItams(completed:true)
            };
            return View("Index",_indmen);
        }
        public IActionResult UnCompleated()
        {
            ViewData["Message"] = "Your application description page.";
           
            _indmen = new IndexMeneger()
            {
                Itams = _toDo.GetItams(completed:false)
            };
            return View("Index",_indmen);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(IndexMeneger index)
        {
            
            await _toDo.AddAsync(new Itam
            {
                Title = index.Title
            });
            _indmen = new IndexMeneger()
            {
                Itams = _toDo.GetItams()
            };
            return View("Index", _indmen);
        }

        public async Task<IActionResult> CheckingAsync(Guid id)
        {
            var itam = _toDo.GetItam(id);
            await _toDo.ChangeConditionAsync(itam);
            _indmen = new IndexMeneger
            {
                Itams = _toDo.GetItams()
            };
            return View("Index", _indmen);
        }

        public async Task DeleteAsync(Guid id)
        {
            var itam = _toDo.GetItam(id);
            await _toDo.DeleteAsync(itam);
            _indmen = new IndexMeneger
            {
                Itams = _toDo.GetItams()
            };
            return;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
