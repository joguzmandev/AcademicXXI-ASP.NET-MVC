using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Services.RecordService
{
    public interface IRecordService : IService<Record>
    {
        bool ExitRecord(String SAcademicYear, String selectAddSubject);

        List<RecordDetails> GetAllSessionBySubject(String selectedAcademicSemester, String selectedSubject);

        Record GetRecordWithSubjectAndSessions(String subjectCode, String semesterCode);

        RecordDetails GetRecordWithRecordDetailsByRDId(String recordDetailsid);

        List<SpRecordStudent> RecordStudent(String RecordDetailId);

        bool UpdateLineRecordStudentDetail(List<SpRecordStudent> list);

        bool ValidateIfGivenSubject(String RecordDetailId, String StudentRegisterNumber);
    }
}