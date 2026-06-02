using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.SqlRepositories
{
    public class SqlScheduleRepository : IScheduleRepository
    {
        private readonly SchoolDbContext _db;

        public SqlScheduleRepository(SchoolDbContext db)
        {
            _db = db;
        }

        public IReadOnlyList<Schedule> GetAll()
        {
            return _db.Schedules
                .Include(s => s.Schedules)
                .ToList();
        }

        public Schedule? GetById(int id)
        {
            return _db.Schedules
                .Include(s => s.Schedules)
                .FirstOrDefault(s => EF.Property<int>(s, "Id") == id);
        }

        public void Save(Schedule schedule)
        {
            var entry = _db.Entry(schedule);
            int currentId = entry.State != EntityState.Detached ? entry.Property<int>("Id").CurrentValue : 0;

            Schedule? existing = null;
            if (currentId != 0)
            {
                existing = _db.Schedules.FirstOrDefault(s => EF.Property<int>(s, "Id") == currentId);
            }

            if (existing == null)
            {
                _db.Schedules.Add(schedule);
            }
            else
            {
                _db.Entry(existing).CurrentValues.SetValues(schedule);
                _db.Entry(existing).Reference(s => s.Schedules).CurrentValue = schedule.Schedules;
            }

            _db.SaveChanges();
        }
    }
}

