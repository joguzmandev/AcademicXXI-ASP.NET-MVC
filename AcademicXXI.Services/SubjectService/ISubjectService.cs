using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicXXI.Services.SubjectService
{
    public interface ISubjectService : IService<Subject>
    {
        Task<IEnumerable<Subject>> GetAllSubjectByStudyPlanAsync(string StudyPlanCode);
        bool ExitCode(string code);
    }
}
