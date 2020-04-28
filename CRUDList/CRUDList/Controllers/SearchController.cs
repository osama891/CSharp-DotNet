using System;
using CRUDList.Models;
using CRUDList.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace CRUDList.Controllers
{
    [Route("Search")]

    public class SearchController: Controller
    {
        private readonly ITask _taskrepository;

        public SearchController(ITask taskrepository)
        {
            _taskrepository = taskrepository;

        }


        [Route("Result/{search}")]
        public ViewResult Result(string search)

        {
            Console.WriteLine(search);
            var tasks = _taskrepository.GetAllTask(search.ToString());

            return View(tasks);
        }

    }
}
