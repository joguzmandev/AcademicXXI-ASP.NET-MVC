using AcademicXXI.Data;
using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace AcademicXXI.Repository.StudentRepository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AcademicXXIDataContext dbContext) : base(dbContext)
        {
        }

        public Student FindStudentWithStudyPlan(Expression<Func<Student, bool>> expression)
        {
            return DbSet.Include(x => x.StudentPlans.Select(c => c.StudyPlan)).Where(expression).SingleOrDefault();
        }

        public List<SpStudentRecordNotes> GetStudentRecordNotes(string StudentID)
        {
            var result = GetStoreProcedure<SpStudentRecordNotes>("Sp_StudentRecordNotes", "@StudentID", StudentID);
            return result;
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