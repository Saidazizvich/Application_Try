using Application_Core.Data;
using Application_Core.Data.ViewModels;
using Application_Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Application_Core.Controllers
{
    public class PersonelController : Controller
    {
        DepartContext context = new DepartContext();

        [Authorize]
        public IActionResult Index()
        {
            var list = context.Personels.Include(x=>x.Departments).ToList();     
            return View(list);
        }

        [HttpGet]
        public IActionResult AddPero()
        {
              List<SelectListItem> list = (from per in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = per.DepartmentName,
                                               Value = per.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.Pero = list;    
                return View();
        }

        [HttpPost]
        public IActionResult AddPero(Personel personel)
        {
            var droplist = context.Departments.Where(p => p.DepartmentId == personel.Departments.DepartmentId).FirstOrDefault();
            personel.Departments = droplist;

            context.Personels.Add(personel);

            context.SaveChanges();                    

            return RedirectToAction("Index",personel);
        }

     

      

    }
}
