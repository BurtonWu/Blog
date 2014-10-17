using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Domain.Blog.Core.AutoMapper;
using Domain.Blog.Entity.Entry;

namespace AppBlog.Models
{
	public class AddEntryViewModel// : IMapper
	{
		[Required]
		public String Passage { get; set; }

		//void IMapper.createMap()
		public void createMap()
		{
			Mapper.CreateMap<AddEntryViewModel, AddEntryRequest>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.Passage, opt => opt.MapFrom(src => src.Passage))
				.ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now.Date)
			);

		}

	}
}