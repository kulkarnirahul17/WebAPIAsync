using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWebAPISample.Data.EntityFramework
{
	public abstract class EntityFrameworkRepository<TItem, TId> : IRepository<TItem, TId>
		where TItem : class
		where TId : struct
	{
		private DbContext _dbContext;
		private DbSet<TItem> _dbSet;
		private string errorMessage;

		public EntityFrameworkRepository(DbContext context)
		{
			this._dbContext = context;
			this._dbSet = context.Set<TItem>();

		}

		public virtual IEnumerable<TItem> GetAll()
		{
			return _dbSet as IEnumerable<TItem>;
		}

		public virtual TItem GetById(TId id)
		{
			var entry = _dbSet.Find(id);
			return entry;
		}

		public virtual void Add(TItem item)
		{
			try
			{
				if (item == null || item == default(TItem))
				{
					throw new ArgumentNullException("item");
				}
				var entry = _dbContext.Entry<TItem>(item);
				if(entry!=null)
				{
					_dbSet.Add(item);
					entry.State = EntityState.Added;					
				}									
			}
			catch (DbEntityValidationException dbEx)
			{
				foreach (var validationErrors in dbEx.EntityValidationErrors)
				{
					foreach (var validationError in validationErrors.ValidationErrors)
					{
						errorMessage += string.Format("Property: {0} Error: {1}",
						validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
					}
				}
				throw new Exception(errorMessage, dbEx);
			}
		}
		
		public void SaveChanges()
		{
			_dbContext.SaveChanges();
		}

		public void AbortChanges()
		{
			throw new NotImplementedException();
		}
	}
}
