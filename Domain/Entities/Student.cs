using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name { get;  set; } = string.Empty;
        public int Age { get;  set; }
        public int ClassId { get;  set; }
        public Class Class { get; set; }

        public List<Grade> grades { get; set; } = new List<Grade>();
        public List<Attendance> attendances { get; set; } = new List<Attendance>();

        public Student() { }
        public Student(string name, int age, Class _class)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name is required");
            if (age < 6)
                throw new ArgumentException("Age must be greater than or equal to 6");

            Name = name;
            Age = age;
            Class = _class;
            ClassId = _class.Id;
            grades = new List<Grade>();
            attendances = new List<Attendance>();
        }

        public void AddGrade(Grade grade)
        {
            if (grade == null)
                throw new ArgumentNullException("Grade must be not be null");

            grades.Add(grade);
        }

        public void AddAttendance(Attendance attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException("Attendance must be not be null");

            attendances.Add(attendance);
        }
    }
}
