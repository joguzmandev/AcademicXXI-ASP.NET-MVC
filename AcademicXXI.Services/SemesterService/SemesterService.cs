using System;
using AcademicXXI.Domain;
using AcademicXXI.Repository.SemesterRepository;

namespace AcademicXXI.Services.SemesterService
{
    public class SemesterService : GenericService<Semester>,ISemesterService
    {
        private ISemesterRepository repo;

        public SemesterService(ISemesterRepository repo):base(repo){
            this.repo = repo;
        }

        public bool ExitSemesterCode(string semesterCode)
        {
            return repo.ExitSemesterCode(semesterCode);
        }
    }
}
