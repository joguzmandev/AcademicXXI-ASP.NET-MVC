using AcademicXXI.Domain;
using AcademicXXI.Repository.ProfessorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.Services.ProfessorService
{
    public class ProfessorService : GenericService<Professor>, IProfessorService
    {
        private IProfessorRepository _repo;

        public ProfessorService(IProfessorRepository repo):base(repo)
        {
            this._repo = repo;
        }
    }
}
