using AcademicXXI.Data;
using AcademicXXI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Repository.ProfessorRepository
{
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(AcademicXXIDataContext dbContext) : base(dbContext)
        {
                
        }
    }
}
