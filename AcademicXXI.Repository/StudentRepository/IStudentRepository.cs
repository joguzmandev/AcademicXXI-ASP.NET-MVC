using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Repository.StudentRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        bool ValidateDocumentID(string documentId);
        bool ValidateRegisterNumber(string registerNumber);
        void Update(Student student);
    }
}
