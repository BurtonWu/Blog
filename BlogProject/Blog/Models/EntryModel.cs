using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Domain.Blog.Core.AutoMapper;
using Domain.Blog.Entity.Entry;

namespace Blog.Models
{
	public class EntryModel : IMapper
	{
		[Key]
		public Int32 Id { get; set; }
		[Required]
		public String Passage { get; set; }

		void IMapper.createMap()
		{
			Mapper.CreateMap<EntryModel, AddEntryRequest>()
				.ForMember(dest => dest.Passage, opt => opt.MapFrom(src => src.Passage))
				.ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now.Date)
			);

		}
		
	}
}