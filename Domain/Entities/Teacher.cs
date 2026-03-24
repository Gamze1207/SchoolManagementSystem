using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementSystem.Domain.Enums;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public List<SubjectType> subjects { get; set; }
        public List<TeacherSchedule> schedules { get; set; }

        public Teacher(int id, string name)
        {
            if (id < 0)
                throw new ArgumentException("Id must be positive");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Teacher name is required");

            Id = id;
            Name = name;
            subjects = new List<SubjectType>();
            schedules = new List<TeacherSchedule>();
        }

        public void AddSubject(SubjectType subject)
        {
            if (subject == default)
                throw new ArgumentNullException("Subject must be not be null");

            subjects.Add(subject);
        }

        public void AddSchedule(TeacherSchedule schedule)
        {
            if (schedule == null)
                throw new ArgumentNullException("Schedule must be not be null");

            schedules.Add(schedule);
        }
    }
}
