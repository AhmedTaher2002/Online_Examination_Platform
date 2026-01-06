namespace ExaminationSystem.Models.Enums
{
    public enum ErrorCode
    {
        NoError = 0,

        InvalidCourseId =101,
        InvalidCourseName =102,
        CourseNotFound=103,
        CourseAreadyExists=104,
        
        
        InvalidInstrutorId=201,
        InvalidInstrutorName=202,
        InstrutorNotFound=203,
        InstrutorAreadyExists=204,

        InvalidStudentId=301,
        InvalidStudentName=302,
        StudentNotFound=303,
        StudentAreadyExists=304,

        InvalidExamId=401,
        InvalidExamType =402,
        ExamNotFound=403,
        ExamAreadyExists=404

        

    }
}
