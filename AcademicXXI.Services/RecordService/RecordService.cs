using AcademicXXI.Domain;
using AcademicXXI.Repository.RecordRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Services.RecordService
{
    public class RecordService : GenericService<Record>, IRecordService
    {
        private IRecordRepository repo;

        public RecordService(IRecordRepository repo):base(repo){
            this.repo = repo;
        }

        public bool ExitRecord(string SAcademicYear, string selectAddSubject)
        {
           return repo.ExitRecord(SAcademicYear, selectAddSubject);
        }
    }
}
