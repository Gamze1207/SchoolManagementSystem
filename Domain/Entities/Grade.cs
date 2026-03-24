using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Grade
    {
        public int Id { get; private set; }
        public int Value { get; private set; }
        public Student Student { get; private set; }
        public Subject Subject { get; private set; }

        public Grade(int id, int value, Student student, Subject subject)
        {
            if (id < 0)
                throw new ArgumentException("Id must be positive");

            if (value < 1 || value > 100)
                throw new ArgumentException("Grade value must be between 1 and 100");

            if (student == null)
                throw new ArgumentNullException("Student must be not be null");

            if (subject == null)
                throw new ArgumentNullException("Subject must be not be null");

            Id = id;
            Value = value;
            Student = student;
            Subject = subject;
        }
    }
}
