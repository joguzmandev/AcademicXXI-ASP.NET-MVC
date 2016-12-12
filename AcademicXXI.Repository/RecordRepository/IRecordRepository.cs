using AcademicXXI.Domain;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AcademicXXI.Repository.RecordRepository
{
    public interface IRecordRepository : IRepository<Record>
    {
        bool ExitRecord(String SAcademicYear, String selectAddSubject);
        List<RecordDetails> GetAllSessionBySubject(String selectedAcademicSemester, String selectedSubject);

    }
}
