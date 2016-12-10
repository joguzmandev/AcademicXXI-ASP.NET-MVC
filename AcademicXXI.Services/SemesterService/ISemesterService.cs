using AcademicXXI.Domain;
using System.Collections.Generic;

namespace AcademicXXI.Services.SemesterService
{
    public interface ISemesterService : IService<Semester>{
        bool ExitSemesterCode(string semesterCode);
        Semester GetSemesterSubjects(string semesterCode);
    }
}
