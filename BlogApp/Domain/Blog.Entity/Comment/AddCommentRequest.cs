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
		public String Comment { get; set; }
		[Required]
		public String DateOfComment { get; set; }
	}
}
