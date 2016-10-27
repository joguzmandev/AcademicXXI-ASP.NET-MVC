using AcademicXXI.Domain;
using AcademicXXI.Data;
using System.Linq;
using System;

namespace AcademicXXI.Repository.StudyPlanRepository
{
    public class StudyPlanRepository : GenericRepository<StudyPlan>, IStudyPlanRepository
    {
        public StudyPlanRepository(AcademicXXIDataContext dbContext):base(dbContext){}

        public bool ExitStudyPlan(string pcode, int pid)
        {
            return DbSet.Any(pc => pc.Code.Contains(pcode) && pc.Id == pid);
        }
    }
}
