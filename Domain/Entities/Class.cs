using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Class
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public List<Student> students { get; set; }
        public List<TeacherSchedule> schedules { get; set; }

        public Class(int id, string name)
        {
            if (id < 0)
                throw new ArgumentException("Id must be positive");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Class name is required");

            Id = id;
            Name = name;
            students = new List<Student>();
            schedules = new List<TeacherSchedule>();
        }

        public void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException("Student must be not be null");

            students.Add(student);
        }

        public void AddSchedule(TeacherSchedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException("Schedule must be not be null");

            schedules.Add(schedule);
        }
    }
}
