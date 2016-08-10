using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademicXXI.Data;

namespace AcademicXXI.Repository.SemesterRepository
{
    public class SemesterRepository : RepositoryGeneric<Semester>, ISemesterRepository
    {
        public SemesterRepository(AcademicXXIDataContext dbContext) : base(dbContext)
        {
        }

        public override void Delete(int? idEntity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Semester entity)
        {
            throw new NotImplementedException();
        }
    }
}
