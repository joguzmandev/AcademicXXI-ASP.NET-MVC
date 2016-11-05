using AcademicXXI.Domain;

namespace AcademicXXI.Repository.StudyPlanRepository
{
    public interface IStudyPlanRepository : IRepository<StudyPlan>{
        bool ExitStudyPlan(string pcode, int? pid=null);
    }
}
