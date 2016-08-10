using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AcademicXXI.Domain;
using AcademicXXI.Repository.SubjectRepository;

namespace AcademicXXI.Services.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository _repo;

        public SubjectService(ISubjectRepository repo)
        {
            this._repo = repo;
        }

        public void Add(Subject entity)
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

        public bool ExitCode(string code)
        {
            return this._repo.ExitCode(code);
        }

        public Subject Find(Expression<Func<Subject, bool>> predicate)
        {
            return this._repo.Find(predicate);
        }

        public List<Subject> FindAll(Expression<Func<Subject, bool>> predicate)
        {
            return this._repo.FindAll(predicate);
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectByStudyPlanAsync(string StudyPlanCode, Guid StudyPlanId)
        {
            return await this._repo.GetAllSubjectByStudyPlanAsync(StudyPlanCode, StudyPlanId);
        }

        public void Update(Subject tEntity)
        {
            this._repo.Update(tEntity);
        }
    }
}
