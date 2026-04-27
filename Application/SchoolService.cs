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
            var teacher = new Teacher(0, name);
            if (subjects != null)
                foreach (var s in subjects)
                    teacher.AddSubject(s);
            teacherRepository.Save(teacher);
        }

        public void AddSubject(Subject subject)
        {
            //Gamze
        }

        public void AddGrade(int studentId, int value, Subject subject)
        {
            //Dzheyda
            var student = studentRepository.GetById(studentId);
            var grade = new Grade(0, value, student, subject);
            student.AddGrade(grade);
            studentRepository.Save(student);
        }

        public void UpdateGrade(int studentId, Grade updatedGrade)
        {
            //Dzheyda
            var student = studentRepository.GetById(studentId);
            var index = student.grades.FindIndex(g => g.Id == updatedGrade.Id);
            if (index == -1)
                throw new KeyNotFoundException("Grade not found");
            student.grades[index] = updatedGrade;
            studentRepository.Save(student);
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
            var schoolClass = new Class(0, name);
            classRepository.Save(schoolClass);

        }

        public void AddStudentToClass(int studentId, int classId)
        {
            //Dzheyda
            var student = studentRepository.GetById(studentId);
            var schoolClass = classRepository.GetById(classId);

            schoolClass.AddStudent(student);
            classRepository.Save(schoolClass);
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
            return gradeRepository.GetAll()
                .Where(g => g.Subject.Type == subject);
        }

        public IEnumerable<(Student Student, double Average)> GetClassAverage(int classId)
        {
            //Dzheyda
            var schoolClass = classRepository.GetById(classId);
            return schoolClass.students.Select(s =>
            {
                double avg = s.grades.Count == 0 ? 0 : s.grades.Average(g => g.Value);
                return (s, avg);
            });
        }

        public (Teacher Teacher, IReadOnlyList<SubjectType> Subjects, IReadOnlyList<TeacherSchedule> Schedules)
        GetTeacherInfo(int teacherId)
        {
            //Dzheyda
            var teacher = teacherRepository.GetById(teacherId);

            return (
                teacher,
                teacher.subjects.AsReadOnly(),
                teacher.schedules.AsReadOnly()
                );
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
            var schedule = teacherScheduleRepository.GetById(scheduleId);

            var updated = new TeacherSchedule(
                schedule.Id,
                schedule.Teacher,
                schedule.Class,
                schedule.Subject,
                schedule.Hours,
                year
            );

            teacherScheduleRepository.Save( updated );
        }

        public IEnumerable<Student> GetTopStudents(double minAverage)
        {
            //Gamze
            return null;
        }

        public IEnumerable<Student> GetProblemStudents(double maxAverage)
        {
            //Dzheyda
            return studentRepository.GetAll()
                .Where(s => s.grades.Count > 0 &&
                            s.grades.Average(g => g.Value) <= maxAverage);
        }
    }
}
