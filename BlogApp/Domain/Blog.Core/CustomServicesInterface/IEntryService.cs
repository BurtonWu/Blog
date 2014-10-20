﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Blog.Core.Services;
using Domain.Blog.Entity.Entry;

namespace Domain.Blog.Core.CustomServicesInterface
{
	public interface IEntryService
	{
		void addEntry(AddEntryRequest entry);
		AddEntryRequest getSingleEntry(Int32 Id);
		void editEntry(EditEntryRequest model);
		void removeEntry(Int32 Id);
	}
}
