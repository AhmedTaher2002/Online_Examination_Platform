using ExaminationSystem.Data;
using ExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories
{
    public class StudentAnswerRepository 
    {
        private readonly Context _context;

        public StudentAnswerRepository()
        {
            _context = new Context();
        }

        public IQueryable<StudentAnswer> GetAll()
        {
            var res = _context.StudentAnswers.Include(sa => sa.SelectedChoice).Include(sa => sa.Question);
            return res;
        }


        internal IQueryable<StudentAnswer> Get(int studentId, int examId)
        {
            var query = _context.StudentAnswers.Where(a => a.StudentId == studentId && a.ExamId == examId && !a.IsDeleted);
            return query;
        }
        public async Task<StudentAnswer?> GetWithTracking(int studentId, int examId)
        {
            return await _context.StudentAnswers.AsTracking().FirstOrDefaultAsync(sa => sa.StudentId == studentId && sa.ExamId == examId&&!sa.IsDeleted);
        }

        
        public async Task Add(StudentAnswer answer)
        {   
            _context.StudentAnswers.Add(answer);
            await _context.SaveChangesAsync();
        }

        public async Task Update(StudentAnswer answer)
        {
            _context.StudentAnswers.Update(answer);
            _context.SaveChanges();
        }


        //--------------------------------SRS BUSINESS HELPERS


        //Get all answers for a specific Student Exam attempt
        public IEnumerable<StudentAnswer> GetAnswersByStudentExam(int studentId,int examId)
        {
            var res= _context.StudentAnswers.Include(sa => sa.SelectedChoice).Include(sa => sa.Question)
                .Where(sa => sa.StudentId == studentId && sa.ExamId == examId).AsNoTracking().ToList();
            return res;
        }

        // Count correct answers
        public int CountCorrectAnswers(int studentId,int examId)
        {
            return _context.StudentAnswers.Include(sa => sa.SelectedChoice)
                    .Count(sa => sa.StudentId == studentId&&sa.ExamId==examId && sa.SelectedChoice.IsCorrect);
        }

        // Remove all answers for an exam attempt (safety / reset)
        public void DeleteByStudentExam(int studentId, int examId)
        {
            var answers = _context.StudentAnswers.Where(sa => sa.StudentId == studentId && sa.ExamId == examId);
        }
        public IEnumerable<StudentAnswer> GetAnswersByStudentExam(int studentExamId)
        {
            var res= _context.StudentAnswers.Include(sa => sa.SelectedChoice).Include(sa => sa.Question)
                .Where(sa => sa.StudentExam.ID == studentExamId).AsNoTracking().ToList();
            return res;
        }

        // Count correct answers
        public int CountCorrectAnswers(int studentExamId)
        {
            return _context.StudentAnswers.Include(sa => sa.SelectedChoice)
                    .Count(sa => sa.StudentExam.ID == studentExamId &&sa.SelectedChoice.IsCorrect);
        }

        // Remove all answers for an exam attempt (safety / reset)
        public void DeleteByStudentExam(int studentExamId)
        {
            var answers = _context.StudentAnswers.Where(sa => sa.StudentExam.ID == studentExamId);
            _context.StudentAnswers.RemoveRange(answers);
            _context.SaveChanges();
        }

        // Check if choice is correct
        public bool IsCorrectChoice(int choiceId)
        {
            return _context.Choices
                .Any(c => c.ID == choiceId && c.IsCorrect);
        }

        internal bool IsAnswered(int studentId, int examId, int questionId)
        {
            return _context.StudentAnswers.Any(sa => sa.StudentId==studentId&&sa.ExamId==examId&&sa.QuestionId==questionId);
        }

        
    }
}

