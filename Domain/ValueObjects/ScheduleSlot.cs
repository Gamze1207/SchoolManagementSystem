using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.ValueObjects
{
    public class ScheduleSlot
    {
        public SchoolDay Day { get; set; }
        public int Period { get; set; }
        public ScheduleSlot(SchoolDay day, int period)
        {
            if (period < 1 || period > 8)
                throw new ArgumentOutOfRangeException("Period must be between 1 and 8.");
            Day = day;
            Period = period;
        }

        public override string ToString()
        {
            return $"{Day} - Period {Period}";
        }
    }
}
