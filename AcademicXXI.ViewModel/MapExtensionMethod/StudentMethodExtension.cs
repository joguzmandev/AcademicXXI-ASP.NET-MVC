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
    public static class StudentMethodExtension
    {
        public static List<StudentViewModel> MapToStudentViewModelToStudentList(this List<Student> listOfStudent )
        {
            return Mapper.Map<List<StudentViewModel>>(listOfStudent);
        }
    }
}
