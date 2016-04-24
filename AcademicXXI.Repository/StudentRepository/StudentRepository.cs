using AcademicXXI.Data;
using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Repository.StudentRepository
{
    public class StudentRepository : RepositoryGeneric<Student>,IStudentRepository
    {
        public StudentRepository(AcademicXXIDataContext dbContext):base(dbContext)
        {
            
        }
    }
}
