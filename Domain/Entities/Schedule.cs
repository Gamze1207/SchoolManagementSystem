using SchoolManagementSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; private set; }
        public TeacherSchedule Schedules { get; private set; }
        public ScheduleSlot Slot { get; private set; }

        public Schedule(int id, TeacherSchedule schedules, ScheduleSlot slot)
        {
            if (id < 0)
                throw new ArgumentException("Id must be positive");
            if (schedules == null)
                throw new ArgumentNullException("Schedules must be not be null");
            if (slot == null)
                throw new ArgumentNullException("Schedule slot must be not be null");

            Id = id;
            Schedules = schedules;
            Slot = slot;
        }
    }
}
