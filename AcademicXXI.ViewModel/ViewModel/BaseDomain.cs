using System;
using AcademicXXI.Helpers;

namespace AcademicXXI.ViewModel.ViewModel
{
    public abstract class BaseDomain
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        
    }
}
