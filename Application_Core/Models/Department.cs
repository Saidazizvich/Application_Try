using System.ComponentModel.DataAnnotations;

namespace Application_Core.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public List<Personel> Personels { get; set; }
    }
}
