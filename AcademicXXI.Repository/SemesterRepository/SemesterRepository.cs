using AcademicXXI.Domain;
using AcademicXXI.Data;

namespace AcademicXXI.Repository.SemesterRepository
{
    public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(AcademicXXIDataContext dbContext) : base(dbContext)
        {
        }
    }
}
