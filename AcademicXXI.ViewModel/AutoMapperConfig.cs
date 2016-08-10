using AutoMapper;
using domain = AcademicXXI.Domain;

namespace AcademicXXI.ViewModel
{
    public static class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            //Map Student to StudentViewModel
            Mapper.CreateMap<domain.Student, ViewModel.StudentViewModel>();
            
            //Map StudentViewModel to Student
            Mapper.CreateMap<ViewModel.StudentViewModel,domain.Student>();

            //Map StudyPlan to StudyPlanViewModel
            Mapper.CreateMap<domain.StudyPlan, ViewModel.StudyPlanViewModel>();

            //Map StudyPlanViewModel to StudyPlan
            Mapper.CreateMap<ViewModel.StudyPlanViewModel, domain.StudyPlan>();


            //Map SubjectViewModel to Subjec
            Mapper.CreateMap<ViewModel.SubjectViewModel, domain.Subject>();

            //Map Subject to SubjectViewModel
            Mapper.CreateMap<domain.Subject,ViewModel.SubjectViewModel>();

            //Map SemesterViewModel to Semester
            Mapper.CreateMap<ViewModel.SemesterViewModel, domain.Semester>();

            //Map Semester to SemesterViewModel
            Mapper.CreateMap<domain.Semester, ViewModel.SemesterViewModel>();

        }
    }
}
