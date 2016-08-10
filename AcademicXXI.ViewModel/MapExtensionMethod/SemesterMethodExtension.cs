using AcademicXXI.Domain;
using AcademicXXI.ViewModel.ViewModel;
using AutoMapper;
using System.Collections.Generic;

namespace AcademicXXI.ViewModel.MapExtensionMethod
{
    public static class SemesterMethodExtension
    {
        public static List<SemesterViewModel> MapToSemesterViewModelListFromSemesterList(this List<Semester> list)
        {
            return Mapper.Map<List<SemesterViewModel>>(list);
        }
    }
}
