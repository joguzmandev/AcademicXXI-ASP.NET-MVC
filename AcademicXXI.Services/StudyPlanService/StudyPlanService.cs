using AcademicXXI.Repository.StudyPlanRepository;
using AcademicXXI.Domain;
using System;
using System.Linq.Expressions;

namespace AcademicXXI.Services.StudyPlanService
{
    public class StudyPlanService : GenericService<StudyPlan>, IStudyPlanService
    {
        private IStudyPlanRepository _repo;

        public StudyPlanService(IStudyPlanRepository repo):base(repo)
        {
            this._repo = repo;
        }

        public bool ExitStudyPlan(string pcode, int pid)
        {
            return this._repo.ExitStudyPlan(pcode, pid);
        }
    }
}
