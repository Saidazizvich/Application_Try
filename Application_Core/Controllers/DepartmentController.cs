using Application_Core.Data;
using Application_Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Application_Core.Controllers
{
	public class DepartmentController : Controller
	{
		DepartContext depart = new DepartContext();


	
        public IActionResult Index()
		{
			

			var list = depart.Departments.ToList();    
			

			return View(list);
		}

		[HttpGet]
		public IActionResult AddDepo()
		{
			return View();	
		}

		[HttpPost]
		public IActionResult AddDepo(Department department)
		{
		     depart.Departments.Add(department);	
			 depart.SaveChanges();	

			return RedirectToAction("Index");	
		}

		
		public IActionResult Delete(int id) 
		{
			var delete = depart.Departments.FirstOrDefault(x=>x.DepartmentId == id);	

			depart.Departments.Remove(delete);	
			depart.SaveChanges();
			return RedirectToAction("Index");	
		}

		[HttpGet]
		public IActionResult Edit(int id) 
		{
			var edit = depart.Departments.Find(id);  
			return View("Edit",edit);
		}

		[HttpPost]
		public IActionResult Edit(Department department) 
		{
		     	
			var update = depart.Departments.Find(department.DepartmentId);

			update.DepartmentName = department.DepartmentName;

			  
			depart.SaveChanges();

			return RedirectToAction("Index");
		}

		public IActionResult Details(int id)
		{
            var valu = depart.Personels.Where(x => x.DepartmentId == id).ToList();
			var department = depart.Departments.Where(x => x.DepartmentId == id).Select(x => x.DepartmentName).FirstOrDefault();
			ViewBag.Depo = department;
            return View(valu);
		}
	}
}
