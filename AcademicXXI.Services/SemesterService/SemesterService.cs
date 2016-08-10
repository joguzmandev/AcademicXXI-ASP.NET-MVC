using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AcademicXXI.Domain;
using AcademicXXI.Repository.SemesterRepository;

namespace AcademicXXI.Services.SemesterService
{
    public class SemesterService : ISemesterService
    {

        private ISemesterRepository _repo;

        public SemesterService(ISemesterRepository repo)
        {
            this._repo = repo;
        }

        public void Add(Semester entity)
        {
            this._repo.Add(entity);
        }

        public void Delete(int? idEntity)
        {
            this._repo.Delete(idEntity);
        }

        public void Dispose()
        {
            this._repo.Dispose();
        }

        public Semester Find(Expression<Func<Semester, bool>> predicate)
        {
            return this._repo.Find(predicate);
        }

        public List<Semester> FindAll(Expression<Func<Semester, bool>> predicate)
        {
            return this._repo.FindAll(predicate);
        }

        public Task<List<Semester>> GetAllAsync()
        {
            return this._repo.GetAllAsync();
        }

        public void Update(Semester tEntity)
        {
            this._repo.Update(tEntity);
        }
    }
}
