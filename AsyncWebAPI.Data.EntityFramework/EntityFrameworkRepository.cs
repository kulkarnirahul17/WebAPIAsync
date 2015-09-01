using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWebAPISample.Data.EntityFramework
{
	public abstract class EntityFrameworkRepository<T> : IRepository<T> where T : class
	{
		private DbContext _dbContext;
		private DbSet<T> _dbSet;

		public EntityFrameworkRepository(DbContext context)
		{
			this._dbContext = context;
			this._dbSet = context.Set<T>();

		}

		public virtual IEnumerable<T> GetAll()
		{
			return _dbSet as IEnumerable<T>;
		}

		public virtual T GetById(long id)
		{
			var entry = _dbSet.Find(id);
			return entry;
		}
	}
}
