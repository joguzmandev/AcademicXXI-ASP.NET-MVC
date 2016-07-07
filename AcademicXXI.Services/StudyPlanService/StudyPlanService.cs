using AcademicXXI.Repository.StudyPlanRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicXXI.Domain;
using System.Linq.Expressions;

namespace AcademicXXI.Services.StudyPlanService
{
    public class StudyPlanService : IStudyPlanService
    {
        private IStudyPlanRepository _repo;

        public StudyPlanService(IStudyPlanRepository repo)
        {
            this._repo = repo;
        }

        public void Add(StudyPlan entity)
        {
            _repo.Add(entity);
        }

        public void Delete(int? idEntity)
        {
            _repo.Delete(idEntity);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public StudyPlan Find(Expression<Func<StudyPlan, bool>> predicate)
        {
            return _repo.Find(predicate);
        }

        public List<StudyPlan> FindAll(Expression<Func<StudyPlan, bool>> predicate)
        {
            return _repo.FindAll(predicate);
        }

        public async Task<List<StudyPlan>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public void Update(StudyPlan tEntity)
        {
            throw new NotImplementedException();
        }
    }
}
