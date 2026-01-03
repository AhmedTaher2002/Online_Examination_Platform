using AutoMapper;
using ExaminationSystem.DTOs.Instructor;
using ExaminationSystem.ViewModels.Course;

namespace ExaminationSystem.DTOs.Course
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
                        //source ==> distination
            //service
            CreateMap < Models.Course, GetAllCoursesDTO>()
                .ForMember(dest => dest.Instructor,
                    opt => opt.MapFrom(src => new GetInstructorInfoDTO
                    {
                        ID = src.Instructor.ID,
                        Name = src.Instructor.FullName
                    }));
            CreateMap<Models.Course, GetByIdCourseDTO>()
                .ForMember(dest => dest.Instructor,
                    opt => opt.MapFrom(src => new GetInstructorInfoDTO
                    {
                        ID = src.Instructor.ID,
                        Name = src.Instructor.FullName
                    }));

            CreateMap<CreateCourseDTO, Models.Course>();
            CreateMap<UpdateCourseDTO, Models.Course>();

            //Controller
            CreateMap<GetAllCoursesDTO, GetAllCoursesViewModel>();
            CreateMap<GetByIdCourseDTO, GetByIdCourseViewModel>();

            CreateMap<CreateCourseViewModel, CreateCourseDTO>();
            CreateMap<UpdateCourseViewModel, UpdateCourseDTO>();
        }
    }
}
