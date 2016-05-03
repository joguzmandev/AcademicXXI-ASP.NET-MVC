using AcademicXXI.Data;
using AcademicXXI.Domain;
using AcademicXXI.Helpers;
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

        public override void Delete(int? idEntity)
        {
            var temp = DbSet.Find(idEntity);
            temp.Status = Status.Delete;
            Save();

        }

        public bool ValidateDocumentID(string documentId)
        {
            
            return DbSet.Any(x => x.DocumentID == documentId);
        }

        public bool ValidateRegisterNumber(string registerNumber)
        {
            return DbSet.Any(x => x.RegisterNumber == registerNumber          );
        }
    }
}
