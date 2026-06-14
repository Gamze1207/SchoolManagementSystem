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
        public string Name { get; set; } = string.Empty;
        public List<Student> students { get; set; } = new List<Student>();
        public List<TeacherSchedule> schedules { get; set; }= new List<TeacherSchedule>();

        public Class(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Class name is required");

            Name = name;
            students = new List<Student>();
            schedules = new List<TeacherSchedule>();
        }
    }
}
