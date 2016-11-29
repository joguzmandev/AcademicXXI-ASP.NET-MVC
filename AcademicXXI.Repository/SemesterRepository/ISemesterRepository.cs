using AcademicXXI.Domain;

namespace AcademicXXI.Repository.SemesterRepository
{
    public interface ISemesterRepository : IRepository<Semester>
    {
        bool ExitSemesterCode(string semesterCode);
    }
}
