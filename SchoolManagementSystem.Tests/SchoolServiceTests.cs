//using NUnit.Framework;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Tests
{
    public class SchoolServiceTests
    {
        /*
        [Test]
        public void CalculateAverageGrade_ReturnsCorrectValue()
        {
            int studentId = 1;

            _gradeRepo.Setup(r => r.GetGradesByStudent(studentId))
                .Returns(new List<Grade>
                {
                new Grade { Value = 5 },
                new Grade { Value = 6 }
                });

            var service = new StudentService(_studentRepo.Object, _gradeRepo.Object);

            double avg = service.CalculateAverage(studentId);

            Assert.AreEqual(5.5, avg);
        }

        [Test]
        public void GetFreeTeachers_ReturnsTeachersWithLessThan18Hours()
        {
            _teacherRepo.Setup(r => r.GetAll()).Returns(new List<Teacher>
        {
            new Teacher { TotalHours = 10 },
            new Teacher { TotalHours = 20 }
        });

            var service = new TeacherService(_teacherRepo.Object);

            var freeTeachers = service.GetFreeTeachers();

            Assert.AreEqual(1, freeTeachers.Count());
            Assert.AreEqual(10, freeTeachers.First().TotalHours);
        }

        [Test]
        public void AddLesson_ThrowsException_WhenTeacherHasConflict()
        {
            int teacherId = 1;

            _scheduleRepo.Setup(r => r.GetTeacherSchedule(teacherId))
                .Returns(new List<Lesson>
                {
                new Lesson { Day = DayOfWeek.Monday, Hour = 1 }
                });

            var service = new ScheduleService(_scheduleRepo.Object);

            Assert.Throws<ScheduleConflictException>(() =>
                service.AddLesson(new Lesson
                {
                    TeacherId = teacherId,
                    Day = DayOfWeek.Monday,
                    Hour = 1
                }));
        }
            */
    }
}
