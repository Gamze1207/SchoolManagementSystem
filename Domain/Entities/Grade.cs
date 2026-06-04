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
        public double Value { get; private set; }
        public int StudentId { get; private set; }
        public Student Student { get; private set; }
        public int SubjectId { get; private set; }
        public Subject Subject { get; private set; }

        public Grade() { }
        public Grade(double value, Student student, Subject subject)
        {
            if (value < 2 || value > 6)
                throw new ArgumentException("Grade value must be between 2 and 6");
            if (student == null)
                throw new ArgumentNullException("Student must be not be null");
            if (subject == null)
                throw new ArgumentNullException("Subject must be not be null");

            Value = value;
            Student = student;
            Subject = subject;
        }
    }
}
