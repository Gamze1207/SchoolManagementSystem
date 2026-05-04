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
            var teacher = new Teacher(0, name);
            if (subjects != null)
                foreach (var s in subjects)
                    teacher.AddSubject(s);
            teacherRepository.Save(teacher);
        }

        public void AddSubject(Subject subject)
        {
            //Gamze
            subjectRepository.Save(subject);
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

            classRepository.Save(schoolClass);
            studentRepository.Save(student);
        }

        public IReadOnlyList<Class> GetAllClasses()
        {
            //Gamze
            return classRepository.GetAll();
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
            var attendance = new Attendance(0, student, date, status);
            attendanceRepository.Save(attendance);
            student.AddAttendance(attendance);
            studentRepository.Save(student);
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
            return studentRepository.GetAll()
                .Where(s=>s.grades.Count>0&&s.grades.Average(x=>x.Value)>=minAverage);
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
