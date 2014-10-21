using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Domain.Blog.Entity.Comment;
using Domain.Blog.Entity.Entry;

namespace BlogApp.Models.Comment
{
	public class CommentViewModel
	{
		#region Properties

		[Key]
		public Int32 Id { get; set; }

		public Int32 EntryId { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Comment must be between 1 and 50 characters")]
		public String Comment { get; set; }

		public String DateOfComment { get; set; }

		public AddEntryRequest Entry { get; set; }

		public AddCommentRequest[] ExistingComments { get; set; }
		#endregion

		#region ctor
		public CommentViewModel(Int32 EntryId)
		{
			this.EntryId = EntryId;
			createMap();
		}

		public CommentViewModel() { createMap(); }
		#endregion

		#region automapper
		public void createMap()
		{
			Mapper.CreateMap<CommentViewModel, AddCommentRequest>()
				.ForMember(dest => dest.EntryId, opt => opt.MapFrom(src => src.EntryId))
				.ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
				.ForMember(dest => dest.DateOfComment, opt => opt.UseValue(DateTime.UtcNow.AddHours(-4)))
				.ForMember(dest => dest.Id, opt => opt.Ignore()
			);

			Mapper.CreateMap<List<AddCommentRequest>, CommentViewModel>()
				.ForMember(dest => dest.ExistingComments, opt => opt.ResolveUsing(src =>
					{
						return src.ToArray();
					}))
				.ForMember(dest => dest.EntryId, opt => opt.Ignore())
				.ForMember(dest => dest.DateOfComment, opt => opt.Ignore())
				.ForMember(dest => dest.Entry, opt => opt.Ignore())
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Comment, opt => opt.Ignore()
			);
		}
		#endregion

	}
}