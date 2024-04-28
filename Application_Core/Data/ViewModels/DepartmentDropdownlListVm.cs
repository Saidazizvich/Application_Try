using Application_Core.Models;

namespace Application_Core.Data.ViewModels
{
    public class DepartmentDropdownlListVm
    {

        public DepartmentDropdownlListVm()
        {
            Departments = new List<Department>();
            Personels = new List<Personel>();
        }

        public List<Department> Departments { get; set; }

        public List<Personel> Personels { get; set; }
    }
}
