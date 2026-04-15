using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure
{
    public class FileTeacherScheduleRepository : ITeacherScheduleRepository
    {

        private readonly FileStorage storage;

        public FileTeacherScheduleRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<TeacherSchedule> GetAll()
        {
            var db = storage.Load();
            return db.TeacherSchedules.AsReadOnly();
        }

        public TeacherSchedule GetById(int id)
        {
            var db = storage.Load();

            foreach (var schedule in db.TeacherSchedules)
            {
                if (schedule.Id == id)
                    return schedule;
            }

            throw new KeyNotFoundException($"TeacherSchedule not found: {id}");
        }

        public void Save(TeacherSchedule _schedule)
        {
            if (_schedule is null)
                throw new ArgumentNullException(nameof(_schedule));

            var db = storage.Load();

            if (_schedule.Id == 0)
            {
                var newSchedule = new TeacherSchedule(
                    db.NextId++,
                    _schedule.Teacher,
                    _schedule.Class,
                    _schedule.Subject,
                    _schedule.Hours
                );

                db.TeacherSchedules.Add(newSchedule);
            }

            else
            {
                bool found = false;

                for (int i = 0; i < db.TeacherSchedules.Count; i++)
                {
                    if (db.TeacherSchedules[i].Id == _schedule.Id)
                    {
                        var updated = new TeacherSchedule(
                            _schedule.Id,
                            _schedule.Teacher,
                            _schedule.Class,
                            _schedule.Subject,
                            _schedule.Hours
                    );

                        db.TeacherSchedules[i] = updated;
                        found = true;
                        break;
                    }
                }

                if (!found)
                    throw new KeyNotFoundException($"TeacherSchedule not found: {_schedule.Id}");
            }

            storage.Save(db);
        }

    }
}
