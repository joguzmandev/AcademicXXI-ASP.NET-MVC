using AcademicXXI.Helpers;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentID { get; set; }
        public string RegisterNumber { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
