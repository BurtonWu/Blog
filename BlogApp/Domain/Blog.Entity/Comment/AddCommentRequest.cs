using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Blog.Entity.Comment
{
	public class AddCommentRequest
	{
	
		[Key]
		public Int32 Id { get; set; }

		[Required]
		public Int32 EntryId { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 1, ErrorMessage="Comment must be between 1 and 50 characters")]
		public String Comment { get; set; }

		[Required]
		public String DateOfComment { get; set; }
	}
}
