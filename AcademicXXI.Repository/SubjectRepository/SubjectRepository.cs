using AcademicXXI.Domain;
using AcademicXXI.Data;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicXXI.Repository.SubjectRepository
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(AcademicXXIDataContext dbContext) : base(dbContext){}

        public bool ExitCode(string code)
        {
            return this.DbSet.Any(c => c.Code.Equals(code));
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectByStudyPlanAsync(string StudyPlanCode)
        {
            return await this.DbSet
                .Where(c => c.StudyPlan.Code == StudyPlanCode)
                .OrderBy(o=>o.Created)
                .ToListAsync();
        }
    }
}
