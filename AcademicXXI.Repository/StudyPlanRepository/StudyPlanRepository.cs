using AcademicXXI.Domain;
using AcademicXXI.Data;
using System.Linq;
using System;

namespace AcademicXXI.Repository.StudyPlanRepository
{
    public class StudyPlanRepository : GenericRepository<StudyPlan>, IStudyPlanRepository
    {
        public StudyPlanRepository(AcademicXXIDataContext dbContext):base(dbContext){}

        public bool ExitStudyPlan(string pcode, int? pid = null)
        {
            return DbSet.Any(x => x.Code.Equals(pcode));
        }
    }
}
