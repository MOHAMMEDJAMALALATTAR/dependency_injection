using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Task2.Models;
using WebApp.Task2.Services;

namespace WebApp.Task2.Controllers
{
    public class ToDoListController : Controller
    {

        IToDoListServices sservices;
        public ToDoListController(IToDoListServices toDoListServices  )
        {
            sservices = toDoListServices;
        }

        public IActionResult Index()
        {
            return View(nameof(Index), sservices.List());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind] ToDoListModel toDoListModel)
        {
            toDoListModel.Id = ToDoListModel.currId++;
            toDoListModel.InsertDate = DateTime.Now;
            sservices.Add(toDoListModel);
            return Index();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var model = sservices.Get(Id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int Id, [Bind] ToDoListModel toDoListModel)
        {
            try
            {
                sservices.Edit(Id, toDoListModel);
                return Index();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var model = sservices.Get(Id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost("[Controller]/Delete/{id}")]
        public IActionResult PostDelete(int Id)
        {
            try
            {
                sservices.Delete(Id);
                return Index();
            }
            catch (System.Exception)
            {
                return NotFound();
            }
        }
    }
}
