using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Domain.Blog.Entity.Entry;

namespace BlogApp.Models.Entry
{
	public class EditEntryViewModel 
	{
		public AddEntryRequest ReplaceThisEntry { get; set; }
		[Required]
		public String DateModified { get; set; }

		#region ctor
		public EditEntryViewModel(AddEntryRequest ReplaceThisEntry)
		{
			this.ReplaceThisEntry = ReplaceThisEntry;
			createMap();
		}

		public EditEntryViewModel() { DateModified = "0"; createMap();  }
		#endregion

		public void createMap()
		{
			Mapper.CreateMap<EditEntryViewModel, EditEntryRequest>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ReplaceThisEntry.Id))
				.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.ReplaceThisEntry.Title))
				.ForMember(dest => dest.Passage, opt => opt.MapFrom(src => src.ReplaceThisEntry.Passage))
				.ForMember(dest => dest.Date, opt => opt.Ignore()
			);

		}
		
	}
}