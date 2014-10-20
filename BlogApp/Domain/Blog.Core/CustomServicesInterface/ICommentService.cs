using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Blog.Entity.Entry;
using Domain.Blog.Entity.Comment;

namespace Domain.Blog.Core.CustomServicesInterface
{
	public interface ICommentService
	{
		AddEntryRequest getSingleEntry(Int32 Id);
		List<AddCommentRequest> getCommentsList(Int32 Id);
		void addComment(AddCommentRequest request);
		void removeComment(Int32 Id);
	}
}
