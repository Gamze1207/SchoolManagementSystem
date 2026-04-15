using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure
{
    public class FileAttendanceRepository : IAttendanceRepository
    {
        private readonly FileStorage storage;

        public FileAttendanceRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public IReadOnlyList<Attendance> GetAll()
        {
            var db = storage.Load();
            return db.Attendances.AsReadOnly();
        }

        public Attendance GetById(int id)
        {
            var db = storage.Load();

            foreach (var attendance in db.Attendances)
            {
                if (attendance.Id == id)
                    return attendance;
            }

            throw new KeyNotFoundException($"Attendance not found: {id}");
        }

        public void Save(Attendance attendance)
        {
            if (attendance is null)
                throw new ArgumentNullException(nameof(attendance));

            var db = storage.Load();

            
            if (attendance.Id == 0)
            {
                var newAttendance = new Attendance(
                    db.NextId++,
                    attendance.Student,
                    attendance.Date,
                    attendance.Status
                );

                db.Attendances.Add(newAttendance);
            }

            else
            {
                bool found = false;

                for (int i = 0; i < db.Attendances.Count; i++)
                {
                    if (db.Attendances[i].Id == attendance.Id)
                    {
                        var updated = new Attendance(
                            attendance.Id,
                            attendance.Student,
                            attendance.Date,
                            attendance.Status
                        );

                        db.Attendances[i] = updated;
                        found = true;
                        break;
                    }
                }

                if (!found)
                    throw new KeyNotFoundException($"Attendance not found: {attendance.Id}");
            }

            storage.Save(db);
        }




    }
}
