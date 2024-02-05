using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp05febAssess.Models;

namespace WebApp05febAssess.Controllers
{
    public class TaskController : Controller
    {
        static List<Tasks> listtasks = new List<Tasks>()
        {
            new Tasks{Id=1,Title="Task_1",Description="Task_1 Description",DueDate=new DateTime(day:12,month:12,year:2021)},
            new Tasks{Id=2,Title="Task_2",Description="Task_2 Description",DueDate=new DateTime(day:20,month:10,year:2022)},
            new Tasks{Id=3,Title="Task_3",Description="Task_3 Description",DueDate=new DateTime(day:03,month:8,year:2029)},
            new Tasks{Id=4,Title="Task_4",Description="Task_4 Description",DueDate=new DateTime(day:19,month:1,year:2000)},
            new Tasks{Id=5,Title="Task_5",Description="Task_5 Description",DueDate=new DateTime(day:10,month:5,year:2028)}
        };
        public IActionResult Index()
        {
            return View(listtasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Tasks());
        }
        [HttpPost]
        public IActionResult Create(Tasks tsk)
        {
            if (tsk != null)
            {
                if (ModelState.IsValid)
                {
                    listtasks.Add(tsk);
                    return RedirectToAction("Index");
                }
            }
            return View(new Tasks());
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
           var tsk = listtasks.FirstOrDefault(e => e.Id == id);


                if (tsk != null)
                {
                    listtasks.Remove(tsk);
                    return RedirectToAction("Index");
                }
            
            return View(listtasks);
        }


        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Tasks newtsk)
        {
            var oldtsk = listtasks.FirstOrDefault(e => e.Id == newtsk.Id);


            if (oldtsk != null)
            {
                listtasks[0].Id = newtsk.Id;
                listtasks[1].Title = newtsk.Title;
                listtasks[2].Description = newtsk.Description;
                listtasks[3].DueDate = newtsk.DueDate;


                return RedirectToAction("Index");
            }

            return View(listtasks);


           

        }


    }
}
