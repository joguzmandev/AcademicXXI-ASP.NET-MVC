using AcademicXXI.Data;
using AcademicXXI.Domain;
using System.Linq;
using System;
using System.Linq.Expressions;
using System.Data.Entity;

namespace AcademicXXI.Repository.StudentRepository
{
    public class StudentRepository : GenericRepository<Student>,IStudentRepository
    {
        public StudentRepository(AcademicXXIDataContext dbContext):base(dbContext){}

        public Student FindStudentWithStudyPlan(Expression<Func<Student, bool>> expression)
        {
            return DbSet.Include(x => x.StudentPlans.Select(c => c.StudyPlan)).Where(expression).SingleOrDefault();   
        }

        public bool ValidateDocumentID(string documentId)
        {
            return DbSet.Any(x => x.DocumentID == documentId);
        }

        public bool ValidateRegisterNumber(string registerNumber)
        {
            return DbSet.Any(x => x.RegisterNumber == registerNumber);
        }
    }
}
