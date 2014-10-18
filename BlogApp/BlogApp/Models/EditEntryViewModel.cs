using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Domain.Blog.Entity.Entry;

namespace BlogApp.Models
{
	public class EditEntryViewModel 
	{
		public String Id { get; set; }
		public String Title { get; set; }
		public String Passage { get; set; }
		[Required]
		public String DateModified { get; set; }

		#region ctor
		public EditEntryViewModel(List<String> replaceThisEntry)
		{
			Id = replaceThisEntry[0];
			Title = replaceThisEntry[1];
			Passage = replaceThisEntry[2];
			DateModified = replaceThisEntry[3];

		}

		public EditEntryViewModel() { DateModified = "0"; }
		#endregion

		public void createMap()
		{
			Mapper.CreateMap<EditEntryViewModel, EditEntryRequest>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
				.ForMember(dest => dest.Passage, opt => opt.MapFrom(src => src.Passage))
				.ForMember(dest => dest.Date, opt => opt.Ignore()
				
				
			);

		}
		
	}
}