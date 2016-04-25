using AcademicXXI.Domain;
using AcademicXXI.Repository;
using AcademicXXI.Repository.StudentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
