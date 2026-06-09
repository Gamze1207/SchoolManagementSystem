using SchoolManagementSystem.Application;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Enums;
using SchoolManagementSystem.Domain.ValueObjects;
using SchoolManagementSystem.Infrastructure.SqlRepositories;
namespace SchoolManagementSystem.Tests
{
    //[TestFixture]
    public class SchoolServiceTests
    {
        //private SqlStudentRepository studentRepo;
        //private SqlClassRepository classRepo;
        //private SqlGradeRepository gradeRepo;
        //private SqlSubjectRepository subjectRepo;
        //private SqlTeacherRepository teacherRepo;
        //private SqlAttendanceRepository attendanceRepo;
        //private SqlScheduleRepository scheduleRepo;
        //private SqlTeacherScheduleRepository teacherScheduleRepo;
        //private SchoolService service;
        //private SchoolDbContext db_test;
        //[SetUp]
        //public void Setup()
        //{
        //    db_test = new SchoolDbContext();
        //    studentRepo = new SqlStudentRepository(db_test);
        //    classRepo = new SqlClassRepository(db_test);
        //    gradeRepo = new SqlGradeRepository(db_test);
        //    subjectRepo = new SqlSubjectRepository(db_test);
        //    teacherRepo = new SqlTeacherRepository(db_test);
        //    attendanceRepo = new SqlAttendanceRepository(db_test);
        //    scheduleRepo = new SqlScheduleRepository(db_test);
        //    teacherScheduleRepo = new SqlTeacherScheduleRepository(db_test);

        //    service = new SchoolService(
        //        attendanceRepo,
        //        classRepo,
        //        gradeRepo,
        //        scheduleRepo,
        //        studentRepo,
        //        subjectRepo,
        //        teacherRepo,
        //        teacherScheduleRepo
        //    );
        //}

        //[Test]
        //public void AddStudent_AddsStudentToRepository()
        //{
        //    var cls = new Class("A") { Id = 1 };
        //    classRepo.Save(cls);

        //    service.AddStudent("Gamze", 17, cls);

        //    Assert.That(studentRepo.GetAll().Count, Is.EqualTo(1));
        //}

        //[Test]
        //public void UpdateStudent_ChangesStudentData()
        //{
        //    var cls = new Class("A") { Id = 1 };
        //    classRepo.Save(cls);

        //    var s = new Student("Old", 10, cls) { Id = 1 };
        //    studentRepo.Save(s);

        //    service.UpdateStudent(1, "New", 20, cls);

        //    Assert.That(studentRepo.GetById(1).Name, Is.EqualTo("New"));
        //}

        //[Test]
        //public void AddTeacher_SavesTeacher()
        //{
        //    service.AddTeacher("Dzheyda", new List<SubjectType> { SubjectType.Math });

        //    Assert.That(teacherRepo.GetAll().Count, Is.EqualTo(1));
        //}

        //[Test]
        //public void AddSubject_SavesSubject()
        //{
        //    var subject = new Subject(SubjectType.Math);

        //    service.AddSubject(subject);

        //    Assert.That(subjectRepo.GetAll().Count, Is.EqualTo(1));
        //}

        //[Test]
        //public void AddGrade_AddsGradeToStudent()
        //{
        //    var s = new Student("A", 15, null) { Id = 1 };
        //    studentRepo.Save(s);

        //    var subj = new Subject(SubjectType.Math) { Id = 1 };
        //    subjectRepo.Save(subj);

        //    service.AddGrade(1, 6, SubjectType.Math);

        //    Assert.That(studentRepo.GetById(1).grades.Count, Is.EqualTo(1));
        //}

        //[Test]
        //public void GetStudentById_ReturnsStudent()
        //{
        //    var s = new Student("A", 15, null) { Id = 1 };
        //    studentRepo.Save(s);

        //    var result = service.GetStudentById(1);

        //    Assert.That(result.Name, Is.EqualTo("A"));
        //}

        //[Test]
        //public void UpdateGrade_ChangesGradeValue()
        //{
        //    var s = new Student("A", 15, null) { Id = 1 };
        //    studentRepo.Save(s);

        //    var subj = new Subject(SubjectType.Math) { Id = 1 };
        //    subjectRepo.Save(subj);

        //    var g = new Grade(4, s, subj) { Id = 1 };
        //    gradeRepo.Save(g);

        //    service.UpdateGrade(1, 1, 6, SubjectType.Math);

        //    Assert.That(gradeRepo.GetById(1).Value, Is.EqualTo(6));
        //}

        //[Test]
        //public void CalculateAverageGrade_ReturnsCorrectAverage()
        //{
        //    var s = new Student("A", 15, null) { Id = 1 };
        //    s.AddGrade(new Grade(4, s, new Subject(SubjectType.Math)));
        //    s.AddGrade(new Grade(6, s, new Subject(SubjectType.Math)));
        //    studentRepo.Save(s);

        //    double avg = service.CalculateAverageGrade(1);

        //    Assert.That(avg, Is.EqualTo(5));
        //}

        //[Test]
        //public void GenerateReportCard_ReturnsStudentData()
        //{
        //    var s = new Student("A", 15, null) { Id = 1 };
        //    studentRepo.Save(s);

        //    var result = service.GenerateReportCard(1);

        //    Assert.That(result.Student.Id, Is.EqualTo(1));
        //}

        //[Test]
        //public void AddClass_SavesClass()
        //{
        //    service.AddClass("A1");

        //    Assert.That(classRepo.GetAll().Count, Is.EqualTo(1));
        //}

        //[Test]
        //public void AddStudentToClass_AssignsClass()
        //{
        //    var cls = new Class("A") { Id = 1 };
        //    classRepo.Save(cls);

        //    var s = new Student("A", 15, null) { Id = 1 };
        //    studentRepo.Save(s);

        //    service.AddStudentToClass(1, 1);

        //    Assert.That(studentRepo.GetById(1).ClassId, Is.EqualTo(1));
        //}

        //[Test]
        //public void GetAllClasses_ReturnsClasses()
        //{
        //    classRepo.Save(new Class("A"));

        //    Assert.That(service.GetAllClasses().Count, Is.EqualTo(1));
        //}

        //[Test]
        //public void UpdateClass_ChangesName()
        //{
        //    var cls = new Class("Old") { Id = 1 };
        //    classRepo.Save(cls);

        //    service.UpdateClass(1, "New");

        //    Assert.That(classRepo.GetById(1).Name, Is.EqualTo("New"));
        //}

        //[Test]
        //public void GetAbsences_ReturnsAttendance()
        //{
        //    var s = new Student("A", 15, null) { Id = 1 };
        //    var att = new Attendance(s, DateTime.Today, AttendanceType.Absent);
        //    s.AddAttendance(att);
        //    studentRepo.Save(s);

        //    var result = service.GetAbsences(1);

        //    Assert.That(result.Count, Is.EqualTo(1));
        //}

        //[Test]
        //public void AddAttendance_AddsRecord()
        //{
        //    var s = new Student("A", 15, null) { Id = 1 };
        //    studentRepo.Save(s);

        //    service.AddAttendance(1, DateTime.Today, AttendanceType.Absent);

        //    Assert.That(studentRepo.GetById(1).attendances.Count, Is.EqualTo(1));
        //}

        //[Test]
        //public void GetGradesBySubject_ReturnsCorrectGrades()
        //{
        //    var s = new Student("A", 15, null) { Id = 1 };
        //    var subj = new Subject(SubjectType.Math) { Id = 1 };
        //    subjectRepo.Save(subj);

        //    var g = new Grade(6, s, subj);
        //    gradeRepo.Save(g);

        //    var result = service.GetGradesBySubject(SubjectType.Math);

        //    Assert.That(result.Count(), Is.EqualTo(1));
        //}

        //[Test]
        //public void GetClassAverage_ReturnsAverages()
        //{
        //    var cls = new Class("A") { Id = 1 };
        //    classRepo.Save(cls);

        //    var s = new Student("A", 15, cls) { Id = 1 };
        //    s.AddGrade(new Grade(6, s, new Subject(SubjectType.Math)));
        //    classRepo.GetById(1).students.Add(s);

        //    var result = service.GetClassAverage(1).ToList();

        //    Assert.That(result[0].Average, Is.EqualTo(6));
        //}

        //[Test]
        //public void GetTeacherInfo_ReturnsTeacher()
        //{
        //    var t = new Teacher("T") { Id = 1 };
        //    teacherRepo.Save(t);

        //    var result = service.GetTeacherInfo(1);

        //    Assert.That(result.Teacher.Id, Is.EqualTo(1));
        //}

        //[Test]
        //public void AddScheduleEntry_SavesSchedule()
        //{
        //    var t = new Teacher("T") { Id = 1 };
        //    teacherRepo.Save(t);

        //    var cls = new Class("A") { Id = 1 };
        //    classRepo.Save(cls);

        //    var subj = new Subject(SubjectType.Math) { Id = 1 };
        //    subj.Teachers.Add(t);
        //    subjectRepo.Save(subj);

        //    service.AddScheduleEntry(1, 1, SubjectType.Math, SchoolDay.Monday, 1);

        //    Assert.That(scheduleRepo.GetAll().Count, Is.EqualTo(1));
        //}

        //[Test]
        //public void GetSchedule_ReturnsSchedules()
        //{
        //    scheduleRepo.Save(new Schedule(null, new ScheduleSlot(SchoolDay.Monday, 1)));

        //    Assert.That(service.GetSchedule().Count, Is.EqualTo(1));
        //}

        //[Test]
        //public void GetFreeTeachers_ReturnsTeachersNotInSlot()
        //{
        //    var t = new Teacher("T") { Id = 1 };
        //    teacherRepo.Save(t);

        //    var free = service.GetFreeTeachers(SchoolDay.Monday, 1);

        //    Assert.That(free.Count(), Is.EqualTo(1));
        //}

        //[Test]
        //public void SetScheduleYear_UpdatesYear()
        //{
        //    var ts = new TeacherSchedule(null, null, SubjectType.Math, 18, 2024) { Id = 1 };
        //    teacherScheduleRepo.Save(ts);

        //    service.SetScheduleYear(1, 2030);

        //    Assert.That(teacherScheduleRepo.GetById(1).Year, Is.EqualTo(2030));
        //}

        //[Test]
        //public void GetTopStudents_ReturnsCorrectStudents()
        //{
        //    var s = new Student("A", 15, null) { Id = 1 };
        //    s.AddGrade(new Grade(6, s, new Subject(SubjectType.Math)));
        //    studentRepo.Save(s);

        //    var result = service.GetTopStudents(5);

        //    Assert.That(result.Count(), Is.EqualTo(1));
        //}

        //[Test]
        //public void GetProblemStudents_ReturnsCorrectStudents()
        //{
        //    var s = new Student("A", 15, null) { Id = 1 };
        //    s.AddGrade(new Grade(2, s, new Subject(SubjectType.Math)));
        //    studentRepo.Save(s);

        //    var result = service.GetProblemStudents(3);

        //    Assert.That(result.Count(), Is.EqualTo(1));
        //}

        //[TearDown]
        //public void TearDown()
        //{
        //    db_test.Dispose();
        //}
    }
}