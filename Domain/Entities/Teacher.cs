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
        public string Name { get; private set; } = string.Empty;
        public List<SubjectType> subjects { get; set; } = new List<SubjectType>();
        public List<TeacherSchedule> schedules { get; set; } = new List<TeacherSchedule>();

        public Teacher(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Teacher name is required");

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
