using AcademicXXI.Domain;
using AcademicXXI.Repository.StudentRepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AcademicXXI.Services.StudentService
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        private IStudentRepository _repo;

        public StudentService(IStudentRepository repo) : base(repo)
        {
            this._repo = repo;
        }

        public Student FindStudentWithStudyPlan(Expression<Func<Student, bool>> expression)
        {
            return this._repo.FindStudentWithStudyPlan(expression);
        }

        public List<SpStudentRecordNotes> GetStudentRecordNotes(string StudentID)
        {
            return this._repo.GetStudentRecordNotes(StudentID);
        }

        public bool ValidateDocumentID(string documentId)
        {
            return this._repo.ValidateDocumentID(documentId);
        }

        public bool ValidateRegisterNumber(string registerNumber)
        {
            return this._repo.ValidateRegisterNumber(registerNumber);
        }
    }
}