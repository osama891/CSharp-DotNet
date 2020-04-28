using System;
using CRUDList.Models;
using CRUDList.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;



namespace CRUDList.Controllers
{
    [Route("Home")]

    public class HomeController : Controller
    {
        private readonly ITask _taskrepository;
        public HomeController(ITask taskrepository)
        {
            _taskrepository = taskrepository;
        }

        [Route("")]
        [Route("Index")]
        [Route("~/")]
        public ViewResult Index()
        {
            return View();

        }

        [Route("Details/{id}")]

        public ViewResult Details(int Id)
        {
            HomeDetailsViewModel homeviewmodel = new HomeDetailsViewModel()
            {
                task = _taskrepository.GetTask(Id),
                title = "Details of Task"

            };
            return View(homeviewmodel);

        }
        [HttpGet]
        [Route("Create")]

        public ViewResult Create(int Id)
        {

            return View();

        }
        [HttpPost]
        [Route("Create")]

        public IActionResult Create(Task tasked)

        {
            if (ModelState.IsValid)
            {
                Task newTask = _taskrepository.AddTask(tasked);


                return RedirectToAction("Details", new { Id = newTask.Id });
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        [Route("Edit/{Id}")]

        public RedirectToActionResult Edit(Task tasked)

        {
            Task newTask = _taskrepository.UpdateTask(tasked);


            return RedirectToAction("Details", new { Id = newTask.Id });

        }





        [Route("Edit/{Id}")]
        public ViewResult Edit (int Id)
        {
            ViewBag.Type = "Edit";
            var task = _taskrepository.GetTask(Id);
            return View("~/Views/Home/Create.cshtml", task);


        }

        [Route("Delete/{Id}")]
        public RedirectToActionResult Delete(int id)
        {
            _taskrepository.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}
