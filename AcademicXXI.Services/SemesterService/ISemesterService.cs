using AcademicXXI.Domain;

namespace AcademicXXI.Services.SemesterService
{
    public interface ISemesterService : IService<Semester>{
        bool ExitSemesterCode(string semesterCode);
    }
}
