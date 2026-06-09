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
        public int Id {  get; private set; }
        public int TeacherId { get;  set; }
        public Teacher Teacher { get; private set; }
        public int ClassId { get;  set; }
        public Class Class { get; private set; }
        public Schedule Schedules { get; private set; }
        public SubjectType Subject { get;  set; }
        public int Hours { get;  set; }
        public int Year { get;  set; }

        public TeacherSchedule() { }
        public TeacherSchedule(Teacher teacher, Class _class, SubjectType subject, int hours, int year)
        {
            if (teacher == null)
                throw new ArgumentNullException("Teacher must be not be null");
            if (_class == null)
                throw new ArgumentNullException("Class must be not be null");
            if (subject == default)
                throw new ArgumentException("Subject type is required");
            if (hours < 18 || hours > 22)
                throw new ArgumentException("Hours must be between 18 and 22");
            if (year < 2000 || year > DateTime.Now.Year + 1)
                throw new ArgumentException("Year must be between 2000 and next year");

            Teacher = teacher;
            Class = _class;
            Subject = subject;
            Hours = hours;
            Year = year;
        }
    }
}
