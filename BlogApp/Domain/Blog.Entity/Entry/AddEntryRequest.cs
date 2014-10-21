using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Blog.Entity.Entry
{
	public class AddEntryRequest
	{
		[Key]
		public Int32 Id { get; set; }

		[Required]
		[StringLength(30, MinimumLength = 1, ErrorMessage="Title must be between 1 and 30 characters")]
		public String Title { get; set; }

		[Required]
		[StringLength(200, MinimumLength = 1, ErrorMessage = "Passage must be between 1 and 200 characters")]
		public String Passage { get; set; }

		[Required]
		public DateTime Date { get; set; }
	}
}
