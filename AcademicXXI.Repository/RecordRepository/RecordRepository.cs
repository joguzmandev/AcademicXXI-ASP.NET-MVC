using AcademicXXI.Data;
using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AcademicXXI.Repository.RecordRepository
{
    public class RecordRepository : GenericRepository<Record>, IRecordRepository
    {
        public RecordRepository(AcademicXXIDataContext dbContext):base(dbContext)
        {

        }

        public bool ExitRecord(string SAcademicYear, string selectAddSubject)
        {
            return DbSet.Any(r => r.SemesterFK.Equals(SAcademicYear) && r.SubjectFK.Equals(selectAddSubject));
        }

        public List<RecordDetails> GetAllSessionBySubject(string selectedAcademicSemester, string selectedSubject)
        {
            return GetGenericDbSet<RecordDetails>()
                .Where(r => r.SemesterFK.Equals(selectedAcademicSemester) && r.SubjectFK.Equals(selectedSubject))
                .ToList();
        }

        public Record GetRecordWithSubjectAndSessions(string subjectCode, string semesterCode)
        {
            var record = DbSet.Include(r => r.RecordDetails)
                              .Include(s => s.Subject).Include("RecordDetails.Professor")
                              .Where(r => r.SemesterFK.Equals(semesterCode) && r.SubjectFK.Equals(subjectCode));
            return record.SingleOrDefault();
        }
    }
}
