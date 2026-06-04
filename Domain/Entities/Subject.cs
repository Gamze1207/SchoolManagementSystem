using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Subject
    {
        public int Id { get; private set; }
        public SubjectType Type { get; private set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public Subject(SubjectType type)
        {
            if (type == default)
                throw new ArgumentException("Subject type is required");

            Type = type;
            Teachers = new List<Teacher>();
        }

        public void AddTeacher(Teacher teacher)
        {
            if (teacher == null)
                throw new ArgumentNullException("Teacher must be not be null");

            Teachers.Add(teacher);
        }
    }
}
