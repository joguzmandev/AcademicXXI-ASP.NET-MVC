using AcademicXXI.Domain;
using AcademicXXI.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;

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

        public Semester GetSemesterSubjects(string semesterCode)
        {
            
            var result = DbSet
                .Include(r => r.Records)
                .Include("Records.Subject")
                .Where(s => s.SemesterCode.Equals(semesterCode));
            return result.SingleOrDefault(); ;
        }
    }
}
