using AsyncWebAPISample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsyncWebAPISample.Data
{
	public interface IRepository<TItem, TId>
	{
		IEnumerable<TItem> GetAll();

		TItem GetById(TId id);

		void Add(TItem item);

		void SaveChanges();

		void AbortChanges();
	}
}
