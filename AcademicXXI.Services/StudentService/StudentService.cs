using AcademicXXI.Domain;
using AcademicXXI.Repository.StudentRepository;

namespace AcademicXXI.Services.StudentService
{
    public class StudentService : ServiceGeneric<Student>, IStudentService
    {
        public StudentService(IStudentRepository repo):base(repo)
        {

        }
        public override void Delete(int? idEntity)
        {
            this._repo.Delete(idEntity);
        }
    }
}
