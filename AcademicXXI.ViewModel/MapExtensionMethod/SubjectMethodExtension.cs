using AcademicXXI.Domain;
using AcademicXXI.ViewModel.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicXXI.ViewModel.MapExtensionMethod
{
    public static class SubjectMethodExtension
    {
        public static List<SubjectViewModel> MapToSubjectViewModelListFromSubjectList(this IEnumerable<Subject> list)
        {
            return Mapper.Map<List<SubjectViewModel>>(list);
        }
        public static SubjectViewModel MapToSubjectViewModelFromSubject(this Subject subject)
        {
            return Mapper.Map<SubjectViewModel>(subject);
        }
        public static Subject MapToSubjectFromSubjectViewModel(this SubjectViewModel subject)
        {
            return Mapper.Map<Subject>(subject);
        }

    }
}
