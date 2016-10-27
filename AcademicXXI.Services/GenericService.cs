using AcademicXXI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Services
{
    public class GenericService<TEntity> : IService<TEntity> where TEntity : class
    {
        private IRepository<TEntity> repo;

        public GenericService(IRepository<TEntity> repo)
        {
            this.repo = repo;
        }

        public void Add(TEntity entity)
        {
            repo.Add(entity);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            return repo.Find(expression);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public void Delete(TEntity tEntity)
        {
            repo.Delete(tEntity);
        }

        public void Update(TEntity tEntity)
        {
            repo.Update(tEntity);
        }

        public void Dispose()
        {
            repo.Dispose();
        }
    }
}
