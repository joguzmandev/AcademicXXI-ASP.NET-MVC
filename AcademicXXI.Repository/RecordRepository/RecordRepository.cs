using AcademicXXI.Data;
using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Repository.RecordRepository
{
    public class RecordRepository : GenericRepository<Record>, IRecordRepository
    {
        public RecordRepository(AcademicXXIDataContext dbContext):base(dbContext)
        {

        }
    }
}
