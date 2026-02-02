using AutoMapper;
using ExaminationSystem.DTOs.Course;
using ExaminationSystem.DTOs.Exam;
using ExaminationSystem.DTOs.Other;
using ExaminationSystem.Services;
using ExaminationSystem.ViewModels.Course;
using ExaminationSystem.ViewModels.Exam;
using ExaminationSystem.ViewModels.Other;
using ExaminationSystem.ViewModels.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExaminationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : BaseController
    {
        private readonly CourseService _courseService;

        public CourseController(IMapper mapper):base(mapper)
        {
            _courseService = new CourseService(mapper);
        }

        [HttpGet("Courses")]
        //[Authorize(Roles= "Instructor")]
        public async Task<ResponseViewModel<IEnumerable<GetAllCoursesViewModel>>> GetAll()
        {
            var result = await _courseService.GetAll();
            return HandleResult<IEnumerable<GetAllCoursesDTO>, IEnumerable<GetAllCoursesViewModel>>(result);
        }

        [HttpGet("GetByID/{id:int}")]
        public async Task<ResponseViewModel<GetByIdCourseViewModel>> GetByID(int id)
        {
            var result = await _courseService.GetByID(id);
            return HandleResult < GetByIdCourseDTO,GetByIdCourseViewModel>(result);
        }

        [HttpGet("filter")]
        public async Task<ResponseViewModel<IEnumerable<GetAllCoursesViewModel>>> Get(int? id, string? name,int? hours)
        {
            var result = await _courseService.Get(id, name,hours);
            return HandleResult<IEnumerable<GetAllCoursesDTO>, IEnumerable<GetAllCoursesViewModel>>(result);
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> Create([FromBody] CreateCourseDTO dto)
        {
            var result = await _courseService.Create(dto);
            return HandleResult<bool,bool>(result);
        }

        [HttpPut("Update{id}")]
        public async Task<ResponseViewModel<bool>> Update(int id, [FromBody] UpdateCourseDTO dto)
        {
            var result = await _courseService.Update(id, dto);
            return HandleResult<bool, bool>(result);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseViewModel<bool>> SoftDelete(int id)
        {
            var result = await _courseService.SoftDelete(id);
            return HandleResult<bool, bool>(result);
        }

        [HttpGet("{courseId}/students")]
        public async Task<ResponseViewModel<IEnumerable<StudentCourseViewModel>>> GetStudentsInCourse(int courseId)
        {
            var students = await _courseService.GetStudentsInCourse(courseId);
            return HandleResult<IEnumerable<StudentCourseDTO>, IEnumerable<StudentCourseViewModel>>(students);
        }

        [HttpPost("{courseId}/AssignInstructor/{instructorId}")]
        public async Task<ResponseViewModel<bool>> AssignInstructorToCourse(int courseId, int instructorId)
        {
            var result = await _courseService.AssignInstructorToCourse(courseId, instructorId);
            return HandleResult<bool, bool>(result);
        }

        [HttpPost("{courseId}/AssignExam/{examId}")]
        public async Task<ResponseViewModel<bool>> AssignExamToCourse(int courseId, int examId)
        {
            var result = await _courseService.AssignExamToCourse(courseId, examId);
            return HandleResult<bool, bool>(result);
        }

        [HttpGet("{courseId}/exams")]
        public async Task<ResponseViewModel<IEnumerable<GetAllExamsViewModel>>> GetExamsForCourse(int courseId)
        {
            var result = await _courseService.GetExamsForCourse(courseId);
            return HandleResult<IEnumerable<GetAllExamsDTO>, IEnumerable<GetAllExamsViewModel>>(result);
        }
    }
}
