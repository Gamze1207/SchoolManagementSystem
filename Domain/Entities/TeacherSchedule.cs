using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class TeacherSchedule
    {
        public int Id { get; private set; }
        public Teacher Teacher { get; private set; }
        public Class Class { get; private set; }
        public SubjectType Subject { get; private set; }
        public int Hours { get; private set; }
        public int Year { get; private set; }

        public TeacherSchedule(int id, Teacher teacher, Class _class, SubjectType subject, int hours, int year)
        {
            if (id < 0)
                throw new ArgumentException("Id must be positive");
            if (teacher == null)
                throw new ArgumentNullException("Teacher must be not be null");
            if (_class == null)
                throw new ArgumentNullException("Class must be not be null");
            if (subject == default)
                throw new ArgumentException("Subject type is required");
            if (hours < 0 && hours > 22)
                throw new ArgumentException("Hours must be between 0 and 22");
            if (year < 2000 || year > DateTime.Now.Year + 1)
                throw new ArgumentException("Year must be between 2000 and next year");
            Id = id;
            Teacher = teacher;
            Class = _class;
            Subject = subject;
            Hours = hours;
            Year = year;
        }
    }
}
