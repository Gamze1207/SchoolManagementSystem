using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Infrastructure.SqlRepositories;
using static System.Net.Mime.MediaTypeNames;

namespace DesktopUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
               .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SchoolDb;TrustServerCertificate=False;Integrated Security=True;TrustServerCertificate=True;")
               .Options;
            using var db = new SchoolDbContext(options);
            IAttendanceRepository attendanceRepo = new SqlAttendanceRepository(db);
            IClassRepository classRepo = new SqlClassRepository(db);
            IGradeRepository gradeRepo = new SqlGradeRepository(db);
            IScheduleRepository scheduleRepo = new SqlScheduleRepository(db);
            IStudentRepository studentRepo = new SqlStudentRepository(db);
            ISubjectRepository subjectRepo = new SqlSubjectRepository(db);
            ITeacherRepository teacherRepo = new SqlTeacherRepository(db);
            ITeacherScheduleRepository teacherScheduleRepo = new SqlTeacherScheduleRepository(db);
            var service = new SchoolService(attendanceRepo, classRepo, gradeRepo, scheduleRepo, studentRepo, subjectRepo, teacherRepo, teacherScheduleRepo);
            Application.Run(new Form1(service));
        }
    }
}