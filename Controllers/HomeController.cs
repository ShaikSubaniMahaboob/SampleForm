using Microsoft.AspNetCore.Mvc;
using SampleForm.DBContext;
using SampleForm.Models;
using System.Diagnostics;

namespace SampleForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository repository;

        public HomeController(ILogger<HomeController> logger, Repository _repository)
        {
            _logger = logger;
            this.repository = _repository;
        }

        public IActionResult Index()
        {
            List<CreateForm> objcreateform = repository.GetCreateForm();
            return View(objcreateform);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult CreateForm(int? id)
        {
            CreateForm objcreateform1 = new CreateForm();
            if (id != 0)
            {

                objcreateform1 = repository.GetDataById(Convert.ToInt32(id));

            }   
            else
            {
                objcreateform1.ID = 0;

                

            }
            return View(objcreateform1);


      


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateForm(CreateForm uc)
        {
            var data = repository.AddCrfeateForm(uc);
            if (uc.ID != 0)
            {
                if (data > 0)
                    TempData["update"] = "updated successfully";
                else
                    TempData["update"] = "Not updated."; 
            }
            else
            {
                if (data > 0)
                {
                    TempData["success"] = "Saved successfully";
                }
                else
                {
                    TempData["error"] = "Not saved.";
                }
            }

            //ViewBag.message = "The user " + uc.Username + " is saved successfully";
            return RedirectToAction("Index");
        }


      

     
        public ActionResult Delete(int id)
        {
            repository.spDeleteCreateForm(id);
              
                TempData["success1"] = "Deleted successfully";
           


            return RedirectToAction("Index");
        }


    }

}
