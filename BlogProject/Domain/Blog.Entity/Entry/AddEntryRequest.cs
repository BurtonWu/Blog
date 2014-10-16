using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Blog.Entity.Entry
{
	public class AddEntryRequest
	{
		[Key]
		public Int32 Id { get; set; }
		[Required]
		public String Passage { get; set; }
		public DateTime Date { get; set; }
	}
}
