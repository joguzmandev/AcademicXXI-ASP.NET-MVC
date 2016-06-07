using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AcademicXXI.Domain;
using AcademicXXI.Repository.StudentRepository;

namespace AcademicXXI.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _repo;
        public StudentService(IStudentRepository repo)
        {
            this._repo = repo;
        }

        public void Add(Student entity)
        {
            this._repo.Add(entity);
        }

        public void Delete(int? idEntity)
        {
            this._repo.Delete(idEntity);
        }

        public List<Student> FindAll(Expression<Func<Student, bool>> predicate)
        {
            return this._repo.FindAll(predicate);
        }

        public Student Find(Expression<Func<Student, bool>> predicate)
        {
            return this._repo.Find(predicate);
        }

        public Task<List<Student>> GetAllAsync()
        {
            return this._repo.GetAllAsync();
        }

        public bool ValidateDocumentID(string documentId)
        {
            return this._repo.ValidateDocumentID(documentId);
        }

        public bool ValidateRegisterNumber(string registerNumber)
        {
            return this._repo.ValidateRegisterNumber(registerNumber);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public void Update(Student tEntity)
        {
            _repo.Update(tEntity);
        }
    }
}
