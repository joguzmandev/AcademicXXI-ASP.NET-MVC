using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Repository.RecordRepository
{
    public interface IRecordRepository : IRepository<Record>
    {
        bool ExitRecord(String SAcademicYear, String selectAddSubject);
    }
}
