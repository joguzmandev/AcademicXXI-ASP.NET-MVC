using System;
using AcademicXXI.Domain;
using AcademicXXI.Data;
using AcademicXXI.Helpers;

namespace AcademicXXI.Repository.StudyPlanRepository
{
    public class StudyPlanRepository : RepositoryGeneric<StudyPlan>, IStudyPlanRepository
    {


        public StudyPlanRepository(AcademicXXIDataContext dbContext):base(dbContext)
        {
            
        }

        public override void Delete(int? idEntity)
        {
            var temp = DbSet.Find(idEntity);
            temp.Status = Status.Delete;
            Save();
        }
    }
}
