using AcademicXXI.Domain;
using System.Collections;
using System.Collections.Generic;

namespace AcademicXXI.Repository.SemesterRepository
{
    public interface ISemesterRepository : IRepository<Semester>
    {
        bool ExitSemesterCode(string semesterCode);
        Semester GetSemesterSubjects(string semesterCode);
    }
}
