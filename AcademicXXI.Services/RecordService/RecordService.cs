using AcademicXXI.Domain;
using AcademicXXI.Repository.RecordRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Services.RecordService
{
    public class RecordService : GenericService<Record>, IRecordService
    {
        private IRecordRepository repo;

        public RecordService(IRecordRepository repo):base(repo){
            this.repo = repo;
        }

        public bool ExitRecord(string SAcademicYear, string selectAddSubject)
        {
           return repo.ExitRecord(SAcademicYear, selectAddSubject);
        }

        public List<RecordDetails> GetAllSessionBySubject(string selectedAcademicSemester, string selectedSubject)
        {
            return repo.GetAllSessionBySubject(selectedAcademicSemester, selectedSubject);
        }

        public Record GetRecordWithSubjectAndSessions(string subjectCode, string semesterCode)
        {
            return repo.GetRecordWithSubjectAndSessions(subjectCode, semesterCode);
        }
    }
}
