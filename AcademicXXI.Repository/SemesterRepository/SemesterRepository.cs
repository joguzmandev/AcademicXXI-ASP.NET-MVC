using AcademicXXI.Domain;
using AcademicXXI.Data;
using System.Linq;
using System;

namespace AcademicXXI.Repository.SemesterRepository
{
    public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(AcademicXXIDataContext dbContext) : base(dbContext)
        {
        }

        public bool ExitSemesterCode(string semesterCode)
        {
            return DbSet.Any(x => x.SemesterCode.Equals(semesterCode));
        }
    }
}
