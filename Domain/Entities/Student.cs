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
        public string Name { get; private set; } = string.Empty;
        public int Age { get; private set; }
        public Class Class { get; private set; }

        public List<Grade> grades { get; set; }
        public List<Attendance> attendances { get; set; }

        public Student(int id, string name, int age, Class _class)
        {
            if (id < 0)
                throw new ArgumentException("Id must be positive");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name is required");

            if (age <= 0)
                throw new ArgumentException("Age must be greater than zero");

            Id = id;
            Name = name;
            Age = age;
            Class = _class;
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
