using AutoMapper;
using ExaminationSystem.ViewModels.Instructor;

namespace ExaminationSystem.DTOs.Instructor
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            //Service
            CreateMap<Models.Instructor, GetAllInstructorsDTO>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.FullName));
            CreateMap<Models.Instructor, GetInstructorByIdDTO>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.FullName));
            CreateMap<Models.Instructor, GetInstructorInfoDTO>()
                .ForMember(i => i.Name, i => i.MapFrom(s => s.FullName));


            CreateMap<CreateInstructorDTO, Models.Instructor>()
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.Name));
            CreateMap<UpdateInstructorDTO, Models.Instructor>()
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.Name));

            //Controller
            CreateMap<GetAllInstructorsDTO, GetAllInstructorsViewModel>();
            CreateMap<GetInstructorByIdDTO, GetInstructorByIdViewModel>();

            CreateMap<CreateInstructorViewModel, CreateInstructorDTO>();
            CreateMap<UpdateInstructorViewModel, UpdateInstructorDTO>();
        }
    }
}
