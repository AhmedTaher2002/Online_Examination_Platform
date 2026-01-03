using AutoMapper;
using ExaminationSystem.ViewModels.Other;

namespace ExaminationSystem.DTOs.Other
{
    public class OtherProfile:Profile
    {
        public OtherProfile() { 
            CreateMap<StudentCourseViewModel,StudentCourseDTO>();

        }
    }
}
