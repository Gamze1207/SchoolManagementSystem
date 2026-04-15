using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure
{
    public class FileScheduleRepository : IScheduleRepository
    {

        private readonly FileStorage storage;

        public FileScheduleRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<Schedule> GetAll()
        {
            var db = storage.Load();
            return db.Schedules.AsReadOnly();
        }

        public Schedule GetById(int id)
        {
            var db = storage.Load();

            foreach (var schedule in db.Schedules)
            {
                if (schedule.Id == id)
                    return schedule;
            }

            throw new KeyNotFoundException($"Schedule not found: {id}");
        }

        public void Save(Schedule _schedule)
        {
            if (_schedule is null)
                throw new ArgumentNullException(nameof(_schedule));

            var db = storage.Load();

            if (_schedule.Id == 0)
            {
                var newSchedule = new Schedule(
                    db.NextId++,
                    _schedule.Schedules,
                    _schedule.Slot
                );

                db.Schedules.Add(newSchedule);
            }

            else
            {
                bool found = false;

                for (int i = 0; i < db.Schedules.Count; i++)
                {
                    if (db.Schedules[i].Id == _schedule.Id)
                    {
                        var updated = new Schedule(
                            _schedule.Id,
                            _schedule.Schedules,
                            _schedule.Slot
                        );

                        db.Schedules[i] = updated;
                        found = true;
                        break;
                    }
                }

                if (!found)
                    throw new KeyNotFoundException($"Schedule not found: {_schedule.Id}");
            }

            storage.Save(db);




        }
    }
}
