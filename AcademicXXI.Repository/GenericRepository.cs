using AcademicXXI.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Repository
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private AcademicXXIDataContext _dbContext;

        protected DbSet<TEntity> DbSet { get; private set; }

        public GenericRepository(AcademicXXIDataContext dbContext)
        {
            this._dbContext = dbContext;
            this.DbSet = _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression).SingleOrDefault();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return _dbContext.Set<TEntity>().ToListAsync<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

        public DbSet<T> GetGenericDbSet<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public List<T> GetStoreProcedure<T>(String storeProcedure, string paramName, string paramValue) where T : class
        {
            string sp = storeProcedure + " " + paramName + " = {0}";
            return _dbContext.Database.SqlQuery<T>(sp, paramValue).ToList();
        }

        public Database GetDatabase()
        {
            return _dbContext.Database;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}