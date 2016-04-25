using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using domain = AcademicXXI.Domain;

namespace AcademicXXI.ViewModel
{
    public static class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.CreateMap<domain.Student, ViewModel.StudentViewModel>();

            Mapper.CreateMap<ViewModel.StudentViewModel,domain.Student>();

        }
    }
}
