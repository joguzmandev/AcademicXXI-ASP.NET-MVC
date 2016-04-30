using AcademicXXI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Services
{
    public abstract class ServiceGeneric<TEntity> : IService<TEntity> where TEntity : class
    {
        protected IRepository<TEntity> _repo;

        public ServiceGeneric(IRepository<TEntity> repo)
        {
            this._repo = repo;
        }
        public void Add(TEntity entity)
        {
            this._repo.Add(entity);
        }

        public abstract void Delete(int? idEntity);

       

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this._repo.Find(predicate);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await this._repo.GetAllAsync();
        }

        public void Dispose()
        {
            this._repo.Dispose();
        }
    }
}
