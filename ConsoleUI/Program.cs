using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Infrastructure;
using System;
using SchoolManagementSystem.Infrastructure.SqlRepositories;

namespace SchoolManagementSystem.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
               .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SchoolManagement;TrustServerCertificate=False;Integrated Security=True;")
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

            var ui = new SchoolUI(service);

            ui.Run();
        }
    }
}
