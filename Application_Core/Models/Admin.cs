using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application_Core.Models
{
	public class Admin
	{
        [Key]
        public  int AdminId { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; } 
        
		[Column(TypeName = "varchar(10)")]
		public string UserName { get; set; }
    }
}
