using SchoolManagementSystem.Application;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Infrastructure;

namespace SchoolManagementSystem.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new FileStorage("school.json");

            IAttendanceRepository attendanceRepo = new FileAttendanceRepository(storage);
            IClassRepository classRepo = new FileClassRepository(storage);
            IGradeRepository gradeRepo = new FileGradeRepository(storage);
            IScheduleRepository scheduleRepo = new FileScheduleRepository(storage);
            IStudentRepository studentRepo = new FileStudentRepository(storage);
            ISubjectRepository subjectRepo = new FileSubjectRepository(storage);
            ITeacherRepository teacherRepo = new FileTeacherRepository(storage);
            ITeacherScheduleRepository teacherScheduleRepo = new FileTeacherScheduleRepository(storage);

            var service = new SchoolService(attendanceRepo, classRepo, gradeRepo, scheduleRepo, studentRepo, subjectRepo, teacherRepo, teacherScheduleRepo);

            var ui = new SchoolUI(service);

            ui.Run();
        }
    }
}
