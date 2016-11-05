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
            if(!pid.HasValue)
            {
                return DbSet.Any(pc => pc.Code.Equals(pcode));
            }
            return DbSet.Any(pc => pc.Code.Equals(pcode) && pc.Id == pid);
        }
    }
}
