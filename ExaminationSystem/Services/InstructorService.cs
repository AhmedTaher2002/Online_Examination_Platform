using AutoMapper;
using ExaminationSystem.DTOs.Course;
using ExaminationSystem.DTOs.Instructor;
using ExaminationSystem.DTOs.Other;
using ExaminationSystem.DTOs.Question;
using ExaminationSystem.DTOs.Student;
using ExaminationSystem.Models;
using ExaminationSystem.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExaminationSystem.Services
{
    public class InstructorService
    {
        private readonly InstructorRepository _instructorRepository;
        private readonly ExamRepository _examRepository;
        private readonly QuestionRepository _questionRepository;
        private readonly ExamQuestionRepository _examQuestionRepository;
        private readonly StudentAnswerRepository _studentAnswerRepository;
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly StudentCourseRepository _studentCourseRepository;

        private readonly IMapper _mapper;
        public InstructorService(IMapper mapper)
        {
            _instructorRepository = new InstructorRepository();
            _examRepository = new ExamRepository();
            _questionRepository = new QuestionRepository();
            _examQuestionRepository = new ExamQuestionRepository();
            _studentRepository = new StudentRepository();
            _courseRepository = new CourseRepository();
            _studentCourseRepository = new StudentCourseRepository();
            _studentAnswerRepository = new StudentAnswerRepository();
            _mapper = mapper;
        }

        public List<GetAllInstructorsDTO> GetAll()
        {
            var instructors = _instructorRepository.GetAll().AsNoTracking().ToList();
            return _mapper.Map<List<GetAllInstructorsDTO>>(instructors);
            /*
            return _instructorRepository.GetAll()
                .Select(i => new GetAllInstructorsDTO
                {
                    ID = i.ID,
                    Name = i.FullName,
                    Email = i.Email
                })
                .AsNoTracking().ToList();
            */
        }

        public async Task<GetInstructorByIdDTO> GetByID(int id)
        {
            if (!_instructorRepository.IsExist(id))
                throw new Exception("Instructor Not Found");

            var instructor = await _instructorRepository.GetByID(id);
            return _mapper.Map<GetInstructorByIdDTO>(instructor);
            /*
            return new GetInstructorByIdDTO
            {
                ID = instructor.ID,
                Name = instructor.FullName,
                Email = instructor.Email
            };
            */

        }
        public IEnumerable<GetAllInstructorsDTO> Get(int? id, string? name, string? email)
        {
            var query = _instructorRepository.GetAll().AsQueryable();
            if (id.HasValue)
            {
                query = query.Where(i => i.ID == id.Value);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(i => i.FullName.Contains(name));
            }
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(i => i.Email.Contains(email));
            }
            var instructor =  query.AsNoTracking().FirstOrDefaultAsync()?? throw new Exception("StudentCourse Not Found"); 
            
            /*
            return new GetAllInstructorsDTO
            {
                ID = instructor.ID,
                Name = instructor.FullName,
                Email = instructor.Email
            };
            */
            return _mapper.Map<IEnumerable<GetAllInstructorsDTO>>(instructor);
        }

        public async Task Create(CreateInstructorDTO dto)
        {
            /*
            Instructor instructor = new Instructor
            {
                FullName = dto.Name,
                Email = dto.Email
            };
            */
            var instructor = _mapper.Map<Instructor>(dto);
            await _instructorRepository.Add(instructor);
        }

        public async Task Update(int id, UpdateInstructorDTO dto)
        {
            if (!_instructorRepository.IsExist(id))
                throw new Exception("Instructor Not Found");

            /*
            Instructor instructor = new Instructor
            {
                ID = id,
                FullName = dto.Name,
                Email = dto.Email
            };
            */

            var instructor = _mapper.Map<Instructor>(dto);
            await _instructorRepository.Update(instructor);
        }

        public async Task SoftDelete(int instructorId)
        {
            if (!_instructorRepository.IsExist(instructorId))
                throw new Exception("Instructor Not Found");

            await _instructorRepository.SoftDelete(instructorId);
        }
        public async Task HardDelete(int instructorId)
        {
            if (!_instructorRepository.IsExist(instructorId))
                throw new Exception("Instructor Not Found");
            
            await _instructorRepository.HardDelete(instructorId);
        }
        public List<GetAllStudentsDTO> GetStudents(int courseId)
        {
            var students = _studentCourseRepository.GetStudentsByCourse(courseId);
            return _mapper.Map<List<GetAllStudentsDTO>>(students);
        }
        public IEnumerable<GetStudentAnswersDTO> GetStudentAnswers(int studentId, int examId)
        {
            var res = _studentAnswerRepository.Get(studentId, examId)
                .Include(a => a.Question).Include(a => a.SelectedChoice)
                .AsNoTracking();
            return _mapper.Map<IEnumerable<GetStudentAnswersDTO>>(res).ToList();

        }
        public async Task AssignStudentToCourse(StudentCourseDTO studentCourseDTO)
        {
            if (!_studentRepository.IsExist(studentCourseDTO.StudentId))
                throw new Exception("Student Not Found");

            if (!_courseRepository.IsExist(studentCourseDTO.CourseId))
                throw new Exception("Course Not Found");

            if (_studentCourseRepository.IsAssigned(studentCourseDTO.StudentId,studentCourseDTO.CourseId))
                throw new Exception("Student Already Assigned To This Course");

            StudentCourse studentCourse = new StudentCourse
            {
                StudentId = studentCourseDTO.StudentId,
                CourseId = studentCourseDTO.CourseId
            };

            await _studentCourseRepository.Add(studentCourse);
        }
        public IEnumerable<GetAllCoursesDTO> GetMyCourses(int instructorId)
        { 
            var cources= _courseRepository.Get(c => c.InstructorId == instructorId).ToList();
            return _mapper.Map<IEnumerable<GetAllCoursesDTO>>(cources);
        }
        public async Task<bool> AssignExamToCourse(int courseID, int examID)
        {
            if (!_courseRepository.IsExist(courseID))
                throw new Exception("Course Not Found");

            if (!_examRepository.IsExist(examID))
                throw new Exception("Exam Not Found");

            var exam = await _examRepository.GetByID(examID);
            exam.CourseId = courseID;

            await _examRepository.Update(exam);
            return true;
        }
        public IEnumerable<GetAllStudentsDTO> GetStudentsInCourse(int courseId)
        {
            if (!_courseRepository.IsExist(courseId))
                throw new Exception("Course Not Found");

            var res= _studentCourseRepository.GetByStudentCourses(courseId)
                .Include(sc => sc.Student)
                .Select(sc => sc.Student)
                .AsNoTracking()
                .ToList();
            return _mapper.Map<IEnumerable<GetAllStudentsDTO>>(res);
        }
        public IEnumerable<GetAllQuestionsDTO> GetQuestionsForInstructor(int instructorId)
        {
            var Questions=_questionRepository.Get(i=>i.InstructorId==instructorId).ToList();
            return _mapper.Map< IEnumerable<GetAllQuestionsDTO>>(Questions);
        }
        public IEnumerable<GetAllQuestionsDTO> GetQuestionsByExam(int examId)
        {
            if (!_examRepository.IsExist(examId))
                throw new Exception("Exam Not Found");

            var res = _examQuestionRepository.GetQuestionsByExam(examId);
            return _mapper.Map<IEnumerable<GetAllQuestionsDTO>>(res);
        }
        public async Task AddQuestionToExam(int examId, int questionId)
        {
            if (!_examRepository.IsExist(examId))
                throw new Exception("Exam Not Found");

            if (!_questionRepository.IsExist(questionId))
                throw new Exception("Question Not Found");

            if (_examQuestionRepository.IsAssigned(examId, questionId))
                throw new Exception("Question Already Added To Exam");

            ExamQuestion examQuestion = new ()
            {
                ExamId = examId,
                QuestionId = questionId
            };

            await _examQuestionRepository.Add(examQuestion);
        }
        public async Task RemoveQuestionFromExam(int examId, int questionId)
        {
            if (!_examQuestionRepository.IsAssigned(examId, questionId))
                throw new Exception("Question Not Assigned To Exam");

            await _examQuestionRepository.SoftDelete(examId, questionId);
        }

    }
}
