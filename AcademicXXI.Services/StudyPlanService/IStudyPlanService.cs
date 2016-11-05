using AcademicXXI.Domain;
using System;
using System.Linq.Expressions;

namespace AcademicXXI.Services.StudyPlanService
{
    public interface IStudyPlanService : IService<StudyPlan>
    {
        bool ExitStudyPlan(string pcode, int? pid = null);
    }
}
