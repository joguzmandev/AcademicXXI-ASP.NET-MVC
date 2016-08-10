using AcademicXXI.Domain;
using AcademicXXI.Data;
using AcademicXXI.Helpers;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcademicXXI.Repository.SubjectRepository
{
    public class SubjectRepository : RepositoryGeneric<Subject>, ISubjectRepository
    {
        public SubjectRepository(AcademicXXIDataContext dbContext) : base(dbContext)
        {
        }

        public override void Delete(int? idEntity)
        {
            var temp = DbSet.Find(idEntity);
            temp.Status = Status.Delete;
            Save();
        }

        public bool ExitCode(string code)
        {
            return this.DbSet.Any(c => c.Code.Equals(code));
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectByStudyPlanAsync(string StudyPlanCode, Guid StudyPlanId)
        {
            return await this.DbSet
                .Where(c => c.StudyPlan.Code == StudyPlanCode)
                .Where(c => c.StudyPlan.Id == StudyPlanId)
                .OrderBy(o=>o.Created)
                .ToListAsync();
           
        }

        public override void Update(Subject entity)
        {
            throw new NotImplementedException();
        }
    }
}
