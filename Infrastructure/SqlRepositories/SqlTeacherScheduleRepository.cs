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
    public class SqlTeacherScheduleRepository:ITeacherScheduleRepository
    {
        private readonly SchoolDbContext _db;

        public SqlTeacherScheduleRepository(SchoolDbContext db)
        {
            _db = db;
        }

        public IReadOnlyList<TeacherSchedule> GetAll()
        {
            return _db.TeacherSchedules
                .Include(t => t.Teacher)
                .Include(t => t.Class)
                .ToList();
        }

        public TeacherSchedule? GetById(int id)
        {
            return _db.TeacherSchedules
                .Include(t => t.Teacher)
                .Include(t => t.Class)
                .FirstOrDefault(t => EF.Property<int>(t, "Id") == id);
        }

        public void Save(TeacherSchedule schedule)
        {
            var entry = _db.Entry(schedule);
            int currentId = entry.State != EntityState.Detached ? entry.Property<int>("Id").CurrentValue : 0;

            TeacherSchedule? existing = null;
            if (currentId != 0)
            {
                existing = _db.TeacherSchedules.FirstOrDefault(t => EF.Property<int>(t, "Id") == currentId);
            }

            if (existing == null)
            {
                _db.TeacherSchedules.Add(schedule);
            }
            else
            {
                _db.Entry(existing).CurrentValues.SetValues(schedule);

                _db.Entry(existing).Reference(t => t.Teacher).CurrentValue = schedule.Teacher;
                _db.Entry(existing).Reference(t => t.Class).CurrentValue = schedule.Class;
            }

            _db.SaveChanges();
        }
    }
}
