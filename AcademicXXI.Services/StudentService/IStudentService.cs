using AcademicXXI.Domain;

namespace AcademicXXI.Services.StudentService
{
    public interface IStudentService : IService<Student>
    {
        bool ValidateDocumentID(string documentId);
        bool ValidateRegisterNumber(string registerNumber);
        
    }
}
