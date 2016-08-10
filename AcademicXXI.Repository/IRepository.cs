using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Repository
{
    public interface IRepository<TEntity>:IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllAsync();
        void Delete(Int32? idEntity);
        void Update(TEntity entity);
        void Save();
       
       
        

    }
}
