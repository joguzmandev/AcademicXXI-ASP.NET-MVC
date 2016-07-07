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
    public static class StudyPlanMethodExtension
    {
        public static List<StudyPlanViewModel> MapToStudyPlanViewModelFromStudyPlanList(this List<StudyPlan> listOfStudyPlan)
        {
            return Mapper.Map<List<StudyPlanViewModel>>(listOfStudyPlan);
        }

        public static StudyPlanViewModel MapStudyPlanViewModelFromStudyPlan(this StudyPlan studyplan)
        {
            return Mapper.Map<StudyPlanViewModel>(studyplan);
        }
    }
}
