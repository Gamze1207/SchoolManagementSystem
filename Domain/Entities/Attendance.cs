using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Attendance
    {
        public int StudentId { get; private set; }
        public Student Student { get; private set; }
        public DateTime Date { get; private set; }
        public AttendanceType Status { get; private set; }

        public Attendance() { }
        public Attendance(Student student, DateTime date, AttendanceType status)
        {
            if (student == null)
                throw new ArgumentNullException("Student must be not be null");
            if (date == default)
                throw new ArgumentException("Date is required");
            if (status == default)
                throw new ArgumentException("Attendance status is required");

            Student = student;
            Date = date;
            Status = status;
        }
    }
}
