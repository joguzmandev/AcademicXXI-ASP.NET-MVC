using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicXXI.Repository.SubjectRepository
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Task<IEnumerable<Subject>> GetAllSubjectByStudyPlanAsync(string StudyPlanCode, Int32 StudyPlanId);
        bool ExitCode(string code);
    }
}
