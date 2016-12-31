using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AcademicXXI.Repository.StudentRepository
{
    public interface IStudentRepository : IRepository<Student>
    {
        bool ValidateDocumentID(string documentId);

        bool ValidateRegisterNumber(string registerNumber);

        Student FindStudentWithStudyPlan(Expression<Func<Student, bool>> expression);

        List<SpStudentRecordNotes> GetStudentRecordNotes(String StudentID);
    }
}