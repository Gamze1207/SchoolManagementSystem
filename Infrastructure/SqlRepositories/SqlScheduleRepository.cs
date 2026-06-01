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
                .FirstOrDefault();//s => s.Id == id
        }

        public void Save(Schedule schedule)
        {
            var existing = _db.Schedules
                .FirstOrDefault();//s => s.Id == schedule.Id

            if (existing == null)
            {
                _db.Schedules.Add(schedule);
            }
            else
            {
                _db.Entry(existing)
                    .CurrentValues
                    .SetValues(schedule);
            }

            _db.SaveChanges();
        }
    }
}

