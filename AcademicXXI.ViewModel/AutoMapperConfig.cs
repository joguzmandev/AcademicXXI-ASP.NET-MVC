using AutoMapper;
using System.Collections.Generic;
using domain = AcademicXXI.Domain;

namespace AcademicXXI.ViewModel
{
    public static class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            //Map Student to StudentViewModel

#pragma warning disable

            //Map Student to StudentViewModel
            Mapper.CreateMap<domain.Student, ViewModel.StudentViewModel>()
                .ForMember(s1 => s1.LineRecordStudentViewModel, opt => opt.MapFrom(s => s.LineRecordStudentDetails));

            //Map StudentViewModel to Student
            Mapper.CreateMap<ViewModel.StudentViewModel, domain.Student>()
                .ForMember(s1 => s1.LineRecordStudentDetails, opt => opt.MapFrom(s => s.LineRecordStudentViewModel));
            //================================================================

            //Map SubjectViewModel to Subjec
            Mapper.CreateMap<ViewModel.SubjectViewModel, domain.Subject>();

            //Map Subject to SubjectViewModel
            Mapper.CreateMap<domain.Subject, ViewModel.SubjectViewModel>();

            //================================================================

            //Map SemesterViewModel to Semester
            Mapper.CreateMap<ViewModel.SemesterViewModel, domain.Semester>();

            //Map Semester to SemesterViewModel
            Mapper.CreateMap<domain.Semester, ViewModel.SemesterViewModel>();

            //================================================================

            //Map StudyPlan to StudyPlanViewModel
            Mapper.CreateMap<domain.StudyPlan, ViewModel.StudyPlanViewModel>();

            //Map StudyPlanViewModel to StudyPlan
            Mapper.CreateMap<ViewModel.StudyPlanViewModel, domain.StudyPlan>();

            //================================================================

            //Map StudentPlan to StudentPlanViewModel
            Mapper.CreateMap<domain.StudentPlan, ViewModel.StudentPlanViewModel>();

            //Map StudentPlanViewModel to StudentPlan
            Mapper.CreateMap<ViewModel.StudentPlanViewModel, domain.StudentPlan>();

            //================================================================

            //Map Record to RecordViewModel

            Mapper.CreateMap<domain.Record, ViewModel.RecordViewModel>()
                .ForMember(s1 => s1.SubjectViewModel, opt => opt.MapFrom(s => s.Subject))
                .ForMember(s1 => s1.RecordDetailsViewModel, opt => opt.MapFrom(s => s.RecordDetails));

            //Map RecordViewModel to Record
            Mapper.CreateMap<ViewModel.RecordViewModel, domain.Record>()
                .ForMember(s1 => s1.Subject, opt => opt.MapFrom(s => s.SubjectViewModel))
                .ForMember(s1 => s1.RecordDetails, opt => opt.MapFrom(s => s.RecordDetailsViewModel));

            //================================================================
            //Map RecordDetails to RecordDetailsViewModel

            Mapper.CreateMap<domain.RecordDetails, ViewModel.RecordDetailsViewModel>()
                .ForMember(s1 => s1.ProfessorViewModel, opt => opt.MapFrom(s => s.Professor));

            //Map RecordDetailsViewModel to RecordDetails
            Mapper.CreateMap<ViewModel.RecordDetailsViewModel, domain.RecordDetails>()
                .ForMember(s1 => s1.Professor, opt => opt.MapFrom(s => s.ProfessorViewModel));

            //================================================================
            //Map Professor to ProfessorViewModel

            Mapper.CreateMap<domain.Professor, ViewModel.ProfessorViewModel>();

            //Map ProfessorViewModel to Professor
            Mapper.CreateMap<ViewModel.ProfessorViewModel, domain.Professor>();

            //================================================================

            Mapper.CreateMap<domain.SpRecordStudent, ViewModel.SpRecordStudentViewModel>();

            //Map ProfessorViewModel to Professor
            Mapper.CreateMap<ViewModel.SpRecordStudentViewModel, domain.SpRecordStudent>();

            //================================================================

            Mapper.CreateMap<domain.LineRecordStudentDetails, ViewModel.LineRecordStudentViewModel>()
                .ForMember(s1 => s1.RecordDetailsViewModel, opt => opt.MapFrom(s => s.RecordDetails))
                .ForMember(s1 => s1.StudentViewModel, opt => opt.MapFrom(s => s.Student));

            //Map ProfessorViewModel to Professor
            Mapper.CreateMap<ViewModel.LineRecordStudentViewModel, domain.LineRecordStudentDetails>()
                .ForMember(s1 => s1.RecordDetails, opt => opt.MapFrom(s => s.RecordDetailsViewModel))
                .ForMember(s1 => s1.Student, opt => opt.MapFrom(s => s.StudentViewModel));
            //================================================================

            Mapper.CreateMap<domain.SpStudentRecordNotes, ViewModel.SpStudentRecordNotesViewModel>();

            //Map ProfessorViewModel to Professor
            Mapper.CreateMap<ViewModel.SpStudentRecordNotesViewModel, domain.SpStudentRecordNotes>();
#pragma warning restore
        }
    }
}