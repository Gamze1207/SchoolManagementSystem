using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Enums;
using SchoolManagementSystem.Domain.ValueObjects;
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
            var student = new Student(name, age, schoolClass);
            studentRepository.Save(student);
        }

        public void UpdateStudent(int id, string name, int age, Class schoolClass)
        {
            //Gamze
            var student = studentRepository.GetById(id);
            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }
            student.Name = name;
            student.Age = age;
            student.Class = schoolClass;
            student.ClassId = schoolClass.Id;
            studentRepository.Update(student);
        }

        public IReadOnlyList<Student> GetAllStudents()
        {
            //Gamze
            return studentRepository.GetAll();
        }

        public void AddTeacher(string name, List<SubjectType> subjects)
        {
            //Dzheyda
            var teacher = new Teacher(name);
            if (subjects != null)
                foreach (var s in subjects)
                    teacher.AddSubject(s);
            teacherRepository.Save(teacher);
        }

        public IReadOnlyList<Teacher> GetAllTeachers()
        {
            //Dzheyda
            return teacherRepository.GetAll();
        }

        public void AddSubject(Subject subject)
        {
            //Gamze
            subjectRepository.Save(subject);
        }

        public IReadOnlyList<Subject> GetAllSubjects()
        {
            //Gamze
            return subjectRepository.GetAll();
        }

        public void AddGrade(int studentId, int value, SubjectType type)
        {
            //Dzheyda
            if (value < 2 || value > 6)
                throw new ArgumentOutOfRangeException(nameof(value), "Grade must be between 2 and 6.");

            var student = studentRepository.GetById(studentId);
            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            var subject = subjectRepository.GetAll()
                .FirstOrDefault(s => s.Type == type);
            if (subject == null)
            {
                throw new KeyNotFoundException("Subject not found");
            }

            var grade = new Grade(value, student, subject);

            student.AddGrade(grade);
            gradeRepository.Save(grade);
        }

        public Student GetStudentById(int id)
        {
            //Dzheyda
            return studentRepository.GetById(id);
        }

        public void UpdateGrade(int studentId, int gradeId, int newValue, SubjectType type)
        {
            //Dzheyda
            var student = studentRepository.GetById(studentId);
            if(student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            var grade = gradeRepository.GetById(gradeId);
            if (grade == null)
            {
                throw new KeyNotFoundException("Grade not found");
            }
            if (newValue < 2 || newValue > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(newValue), "Grade must be between 2 and 6.");
            }
            if (grade.StudentId != studentId)
            {
                throw new InvalidOperationException("Grade does not belong to the specified student");
            }

                var subject = subjectRepository
                .GetAll()
                .FirstOrDefault(s => s.Type == type);
            if (subject == null)
            {
                throw new KeyNotFoundException("Subject not found");
            }

            grade.Value = newValue;
            grade.SubjectId = subject.Id;
            grade.Subject  = subject;

            gradeRepository.Update(grade);

        }

        public double CalculateAverageGrade(int studentId)
        {
            //Gamze
            var student = studentRepository.GetById(studentId);
            if (student == null)
            { 
                throw new KeyNotFoundException("Student not found"); 
            }
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
            if (student == null)
            { 
                throw new KeyNotFoundException("Student not found"); 
            }

            double avg = student.grades.Count==0?0:student.grades.Average(x => x.Value);
            return (student, student.grades, student.attendances, avg);
        }

        public void AddClass(string name)
        {
            //Dzheyda 
            var schoolClass = new Class(name);
            classRepository.Save(schoolClass);

        }

        public void AddStudentToClass(int studentId, int classId)
        {
            //Dzheyda
            var student = studentRepository.GetById(studentId);
            if ( student == null ) {
                throw new KeyNotFoundException("Student not found");
            }
            var schoolClass = classRepository.GetById(classId);
            if (schoolClass == null) {
                throw new KeyNotFoundException("Class not found");
            }
            student.ClassId = schoolClass.Id;
            student.Class = schoolClass;
            studentRepository.Update(student);
        }

        public IReadOnlyList<Class> GetAllClasses()
        {
            //Gamze
            return classRepository.GetAll();
        }

        public void UpdateClass(int classId, string newName)
        {
            //Gamze
            var schoolClass = classRepository.GetById(classId);
            if (schoolClass == null)
                throw new KeyNotFoundException("Class not found");

            schoolClass.Name = newName;
            classRepository.Save(schoolClass);
        }

        public IReadOnlyList<Attendance> GetAbsences(int studentId)
        {
            //Gamze
            var student = studentRepository.GetById(studentId);
            if (student == null)
            { 
                throw new KeyNotFoundException("Student not found");
            }
            return student.attendances;
        }

        public void AddAttendance(int studentId, DateTime date, AttendanceType status)
        {
            //Gamze
            var student = studentRepository.GetById(studentId);
            if (student == null) 
            { 
                throw new KeyNotFoundException("Student not found");
            }

            var attendance = new Attendance(student, date, status);
            attendanceRepository.Save(attendance);
            student.AddAttendance(attendance);
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
            if (teacher == null)
            {
                throw new NullReferenceException("Teacher not found");
            }

            return (
                teacher,
                teacher.subjects.AsReadOnly(),
                teacher.schedules.AsReadOnly()
                );
        }

        public void AddScheduleEntry(int classId, int teacherId, SubjectType subjectType, SchoolDay day, int period)
        {
            //Gamze
            var teacher = teacherRepository.GetById(teacherId);
            if (teacher == null)
            {
                throw new KeyNotFoundException("Teacher not found");
            }

            var schoolClass = classRepository.GetById(classId);
            if (schoolClass == null)
            {
                throw new KeyNotFoundException("Class not found");
            }

            var subject = subjectRepository.GetAll()
                .FirstOrDefault(s => s.Type == subjectType);
            if (subject == null)
            {
                throw new KeyNotFoundException("Subject not found");
            }

            bool teacherCanTeach = teacher.subjects.Contains(subject.Type);
            if (!teacherCanTeach)
            {
                throw new InvalidOperationException("Teacher cannot teach this subject");
            }

            var allSchedules = scheduleRepository.GetAll();

            bool classConflict = allSchedules.Any(s =>
                s.Schedules.ClassId == classId &&
                s.Slot.Day == day &&
                s.Slot.Period == period);
            if (classConflict)
            {
                throw new InvalidOperationException("Class already has a subject at this time");
            }

            bool teacherConflict = allSchedules.Any(s =>
                s.Schedules.TeacherId == teacherId &&
                s.Slot.Day == day &&
                s.Slot.Period == period);
            if (teacherConflict)
            {
                throw new InvalidOperationException("Teacher already has a class at this time");
            }

            int weeklyHours = allSchedules.Count(s =>
                s.Schedules.TeacherId == teacherId);
            if (weeklyHours >= 18)
            {
                throw new InvalidOperationException("Teacher has reached weekly hour limit");
            }

            var teacherSchedule = teacherScheduleRepository.GetAll()
                .FirstOrDefault(ts =>
                ts.TeacherId == teacherId &&
                ts.ClassId == classId &&
                ts.Subject == subjectType &&
                ts.Year == DateTime.Now.Year);

            if (teacherSchedule == null)
            {
                teacherSchedule = new TeacherSchedule(
                    teacher,
                    schoolClass,
                    subjectType,
                    1,
                    DateTime.Now.Year
                );
            }
            else
            {
                teacherSchedule.Hours += 1;
            }

            var slot = new ScheduleSlot(day, period);
            var schedule = new Schedule(teacherSchedule, slot);

            scheduleRepository.Save(schedule);
        }

        public IReadOnlyList<Schedule> GetSchedule()
        {
            //Gamze
            return scheduleRepository.GetAll();
        }

        public IEnumerable<Teacher> GetFreeTeachers(SchoolDay day, int period)
        {
            //Gamze
            var busyTeacherIds = scheduleRepository.GetAll()
                .Where(s => s.Slot.Day == day && s.Slot.Period == period)
                .Select(s => s.Schedules.TeacherId)
                .ToHashSet();
            return teacherRepository.GetAll()
                .Where(t => !busyTeacherIds.Contains(t.Id));
        }

        public void SetScheduleYear(int scheduleId, int year)
        {
            //Dzheyda
            var schedule = teacherScheduleRepository.GetById(scheduleId);

            if (schedule == null)
            {
                throw new KeyNotFoundException("Schedule not found");
            }

           schedule.Year = year;

            teacherScheduleRepository.Save(schedule);
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
