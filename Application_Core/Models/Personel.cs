using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application_Core.Models
{
	public class Personel
	{
		[Key]
		public int PersonelId { get; set; }
		public string PersonelName { get; set; }
		public string PersonelSurName { get; set; }
		public string PersonelCity { get; set; }

        public int DepartmentId { get; set; }
        public Department Departments { get; set; }
    }
}