using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.ViewModel.ViewModel
{
    public class ProfessorViewModel : BaseDomain
    {
        public String FullName { get; set; }
        public String DocumentID { get; set; }

        //One Professor has many RecordDetails
        public virtual List<RecordDetailsViewModel> RecordDetailsViewModel { get; set; }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
