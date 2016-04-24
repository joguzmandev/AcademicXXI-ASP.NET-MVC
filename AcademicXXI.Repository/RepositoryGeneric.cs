using AcademicXXI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Repository
{
    public class RepositoryGeneric<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AcademicXXIDataContext _dbContext;

        public RepositoryGeneric(AcademicXXIDataContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        public void Add(TEntity entity)
        {
            using (_dbContext)
            {
                _dbContext.Set<TEntity>().Add(entity);
                this.Save();
            }
        }

        public void Delete(int? idEntity)
        {
            //Valorar este metodo debido a que no se van a elimianar
            //Datos de la DB sino cambiar el estado de registro
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            using (_dbContext)
            {
                return _dbContext.Set<TEntity>().Where(predicate).FirstOrDefault();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (_dbContext)
            {
                return _dbContext.Set<TEntity>().ToList<TEntity>();
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            
            if(this._dbContext != null)
            {
                this._dbContext.Dispose();
                
            }
        }
    }
}
