using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application
{
    public class SchoolService
    {
        private readonly IAttendanceRepository attendanceRepository;
        private readonly IClassRepository classRepository;
        private readonly IGradeRepository gradeRepository;
        private readonly IScheduleRepository scheduleRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ISubjectRepository subjectRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly ITeacherScheduleRepository teacherScheduleRepository;

        public SchoolService(IAttendanceRepository attendanceRepo, IClassRepository classRepo, IGradeRepository gradeRepo,
            IScheduleRepository scheduleRepo, IStudentRepository studentRepo, ISubjectRepository subjectRepo, ITeacherRepository teacherRepo,
            ITeacherScheduleRepository teacherScheduleRepo)
        {
            this.attendanceRepository = attendanceRepo;
            this.classRepository = classRepo;
            this.gradeRepository = gradeRepo;
            this.scheduleRepository = scheduleRepo;
            this.studentRepository = studentRepo;
            this.subjectRepository = subjectRepo;
            this.teacherRepository = teacherRepo;
            this.teacherScheduleRepository = teacherScheduleRepo;
        }

        public void AddStudent(string name, int age, Class schoolClass)
        {
            //Gamze
        }

        public void UpdateStudent(int id, string name, int age, Class schoolClass)
        {
            //Gamze
        }

        public void AddTeacher(string name, List<SubjectType> subjects)
        {
            //Dzheyda
        }

        public void AddSubject(Subject subject)
        {
            //Gamze
        }

        public void AddGrade(int studentId, int value, Subject subject)
        {
            //Dzheyda
        }

        public void UpdateGrade(int studentId, Grade updatedGrade)
        {
            //Dzheyda
        }

        public double CalculateAverageGrade(int studentId)
        {
            //Gamze
            return 0;
        }

        public (Student Student, IReadOnlyList<Grade> Grades, IReadOnlyList<Attendance> Absences, double Average)
        GenerateReportCard(int studentId)
        {
            //Gamze
            return (null, null, null, 0);
        }

        public void AddClass(string name)
        {
            //Dzheyda 
        }

        public void AddStudentToClass(int studentId, int classId)
        {
            //Dzheyda
        }

        public IReadOnlyList<Attendance> GetAbsences(int studentId)
        {
            //Gamze
            return null;
        }

        public void AddAttendance(int studentId, DateTime date, AttendanceType status)
        {
            //Gamze
        }

        public IEnumerable<Grade> GetGradesBySubject(SubjectType subject)
        {
            //Dzheyda
            return null;
        }

        public IEnumerable<(Student Student, double Average)> GetClassAverage(int classId)
        {
            //Dzheyda
            return null;
        }

        public (Teacher Teacher, IReadOnlyList<SubjectType> Subjects, IReadOnlyList<TeacherSchedule> Schedules)
        GetTeacherInfo(int teacherId)
        {
            //Dzheyda
            return (null, null, null);
        }

        public IReadOnlyList<Schedule> GetSchedule()
        {
            //Gamze
            return null;
        }

        public IEnumerable<Teacher> GetFreeTeachers(SchoolDay day, int period)
        {
            //Gamze
            return null;
        }

        public void SetScheduleYear(int scheduleId, int year)
        {
            //Dzheyda
        }

        public IEnumerable<Student> GetTopStudents(double minAverage)
        {
            //Gamze
            return null;
        }

        public IEnumerable<Student> GetProblemStudents(double maxAverage)
        {
            //Dzheyda
            return null;
        }
    }
}
