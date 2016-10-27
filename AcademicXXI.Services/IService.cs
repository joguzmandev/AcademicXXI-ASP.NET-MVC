using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Services
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        TEntity Find(Expression<Func<TEntity, bool>> expression);
        Task<List<TEntity>> GetAllAsync();
        void Delete(TEntity tEntity);
        void Update(TEntity tEntity);
    }
}
