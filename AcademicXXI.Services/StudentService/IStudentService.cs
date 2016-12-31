using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AcademicXXI.Services.StudentService
{
    public interface IStudentService : IService<Student>
    {
        bool ValidateDocumentID(string documentId);

        bool ValidateRegisterNumber(string registerNumber);

        Student FindStudentWithStudyPlan(Expression<Func<Student, bool>> expression);

        List<SpStudentRecordNotes> GetStudentRecordNotes(string StudentID);
    }
}