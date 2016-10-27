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
        TEntity Find(Expression<Func<TEntity, bool>> expression);
        Task<List<TEntity>> GetAllAsync();
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
