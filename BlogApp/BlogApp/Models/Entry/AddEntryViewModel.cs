using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Domain.Blog.Core.AutoMapper;
using Domain.Blog.Entity.Entry;

namespace BlogApp.Models.Entry
{
	public class AddEntryViewModel
	{
		[Required]
		[StringLength(30, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 30 characters")]
		public String Title { get; set; }

		[Required]
		[StringLength(200, MinimumLength = 1, ErrorMessage = "Passage must be between 1 and 200 characters")]
		public String Passage { get; set; }

		public AddEntryViewModel()
		{
			createMap();
		}
		public void createMap()
		{
			Mapper.CreateMap<AddEntryViewModel, AddEntryRequest>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
				.ForMember(dest => dest.Passage, opt => opt.MapFrom(src => src.Passage))
				.ForMember(dest => dest.Date, opt => opt.UseValue(DateTime.UtcNow.AddHours(-4))
			);

		}

	}
}