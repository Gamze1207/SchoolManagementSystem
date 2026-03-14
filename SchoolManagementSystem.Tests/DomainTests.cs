//using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Tests
{
    public class DomainTests
    {
        /*
        [Test]
        public void FullName_ReturnsCorrectValue()
        {
            var student = new Student { FirstName = "Ivan", LastName = "Petrov" };

            Assert.AreEqual("Ivan Petrov", student.FullName);
        }

        [Test]
        public void AddGrade_IncreasesGradeCount()
        {
            var student = new Student();
            student.AddGrade(new Grade { Value = 5 });

            Assert.AreEqual(1, student.Grades.Count);
        }

        [Test]
        public void CanTeachSubject_ReturnsTrue()
        {
            var teacher = new Teacher();
            teacher.Subjects.Add(new Subject { Name = "Math" });

            Assert.IsTrue(teacher.CanTeach("Math"));
        }

        [Test]
        public void TotalHours_ReturnsCorrectSum()
        {
            var teacher = new Teacher();
            teacher.Schedule.Add(new TeacherSchedule { Hours = 10 });
            teacher.Schedule.Add(new TeacherSchedule { Hours = 8 });

            Assert.AreEqual(18, teacher.TotalHours);
        }

        [Test]
        public void IsValid_ReturnsTrueForValidValue()
        {
            var grade = new Grade { Value = 6 };
            Assert.IsTrue(grade.IsValid());
        }

        [Test]
        public void IsValid_ReturnsFalseForInvalidValue()
        {
            var grade = new Grade { Value = 10 };
            Assert.IsFalse(grade.IsValid());
        }

        [Test]
        public void AddStudent_IncreasesStudentCount()
        {
            var schoolClass = new SchoolClass();
            schoolClass.AddStudent(new Student());

            Assert.AreEqual(1, schoolClass.Students.Count);
        }

        [Test]
        public void Attendance_ExcusedFlag_WorksCorrectly()
        {
            var attendance = new Attendance { IsExcused = true };
            Assert.IsTrue(attendance.IsExcused);
        }

        [Test]
        public void HasConflicts_ReturnsTrue_WhenLessonsOverlap()
        {
            var schedule = new Schedule();

            schedule.AddLesson(new Lesson { Day = DayOfWeek.Monday, Hour = 1 });
            schedule.AddLesson(new Lesson { Day = DayOfWeek.Monday, Hour = 1 });

            Assert.IsTrue(schedule.HasConflicts());
        }
        */
    }
}
