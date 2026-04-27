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
            var student = new Student(0,name, age, schoolClass);
            studentRepository.Save(student);
        }

        public void UpdateStudent(int id, string name, int age, Class schoolClass)
        {
            //Gamze
            var existing = studentRepository.GetById(id);
            var updated = new Student(id, name, age, schoolClass);
            foreach (var item in existing.grades)
            {
                updated.AddGrade(item);
            }
            foreach (var item in existing.attendances)
            {
                updated.AddAttendance(item);
            }
            studentRepository.Save(updated);
        }

        public void AddTeacher(string name, List<SubjectType> subjects)
        {
            //Dzheyda
        }

        public void AddSubject(Subject subject)
        {
            //Gamze
            subjectRepository.Save(subject);
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
            var student = studentRepository.GetById(studentId);
            if (student.grades.Count == 0)
            {
                return 0;
            }
            return student.grades.Average(x => x.Value);
        }

        public (Student Student, IReadOnlyList<Grade> Grades, IReadOnlyList<Attendance> Absences, double Average)
        GenerateReportCard(int studentId)
        {
            //Gamze
            var student = studentRepository.GetById(studentId);
            double avg = student.grades.Count==0?0:student.grades.Average(x => x.Value);
            return (student, student.grades, student.attendances, avg);
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
            return studentRepository.GetById(studentId).attendances;
        }

        public void AddAttendance(int studentId, DateTime date, AttendanceType status)
        {
            //Gamze
            var student = studentRepository.GetById(studentId);
            var attendances = new Attendance(0,student, date, status);
            student.AddAttendance(attendances);
            studentRepository.Save(student);
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
            return scheduleRepository.GetAll();
        }

        public IEnumerable<Teacher> GetFreeTeachers(SchoolDay day, int period)
        {
            //Gamze
            return teacherRepository.GetAll().Where(t => !t.schedules.Any(s =>
            s.Class != null && s.Hours > 0 && s.Class.schedules.Any(c =>
            c.Id == s.Id && c.Class.schedules.Any(slot => 
            slot.Id == s.Id && slot.Class.schedules.Any()))));
        }

        public void SetScheduleYear(int scheduleId, int year)
        {
            //Dzheyda
        }

        public IEnumerable<Student> GetTopStudents(double minAverage)
        {
            //Gamze
            return studentRepository.GetAll()
                .Where(s=>s.grades.Count>0&&s.grades.Average(x=>x.Value)>=minAverage);
        }

        public IEnumerable<Student> GetProblemStudents(double maxAverage)
        {
            //Dzheyda
            return null;
        }
    }
}
