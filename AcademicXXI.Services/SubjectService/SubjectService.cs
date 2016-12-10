using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcademicXXI.Domain;
using AcademicXXI.Repository.SubjectRepository;

namespace AcademicXXI.Services.SubjectService
{
    public class SubjectService :GenericService<Subject>, ISubjectService
    {
        private ISubjectRepository _repo;

        public SubjectService(ISubjectRepository repo):base(repo)
        {
            this._repo = repo;
        }

        public bool ExitCode(string code)
        {
            return this._repo.ExitCode(code);
        }

        public Task<IEnumerable<Subject>> GetAllSubjectByStudyPlanAsync(string StudyPlanCode)
        {
            return this._repo.GetAllSubjectByStudyPlanAsync(StudyPlanCode);
        }
    }
}
