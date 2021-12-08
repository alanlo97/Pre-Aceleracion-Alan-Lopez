using Challenge.Context;
using Challenge.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Repositories
{
    public abstract class BaseRepository <TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		private readonly ChallengeContext _dbContext;
		protected BaseRepository(ChallengeContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IEnumerable<TEntity>> GetAll()
		{
			return await _dbContext.Set<TEntity>().ToListAsync() ;
		}

		public async Task<TEntity> GetById(int id)
		{
			return await _dbContext.Set<TEntity>().FindAsync(id);
		}

		public async Task<TEntity> Insert(TEntity entity)
		{
			_dbContext.Set<TEntity>().Add(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<TEntity> Update(TEntity entity)
		{
			_dbContext.Entry(entity).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();

			return entity;
		}

		public async Task Delete(int id)
		{
			var entity = await GetById(id);

			if (entity == null)
				throw new Exception("Entidad no encontrada");

			_dbContext.Set<TEntity>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}
