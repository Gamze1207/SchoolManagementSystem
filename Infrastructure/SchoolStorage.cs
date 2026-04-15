using System.Collections.Generic;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Infrastructure
{
    public class SchoolStorage
    {
        public int NextId { get; set; } = 1;
        public List<Attendance> Attendances { get; set; } = new();

        public List<Class> Classes { get; set; } = new();

        public List<Schedule> Schedules { get; set; } = new();

        public List<Student> Students { get; set; } = new();

        public List<Subject> Subjects { get; set; } = new();

        public List<Teacher> Teachers { get; set; } = new();

        public List<TeacherSchedule> TeacherSchedules { get; set; } = new();

        public List<Grade> Grades { get; set; } = new();
    }
}
