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
                .FirstOrDefault(t => t.Id == id);
        }

        public void Save(TeacherSchedule schedule)
        {
            var existing = _db.TeacherSchedules
                .Include(t => t.Teacher)
                .Include(t => t.Class)
                .FirstOrDefault(t => t.Id == schedule.Id);

            if (existing == null)
            {
                _db.TeacherSchedules.Add(schedule);
            }
            else
            {
                _db.Entry(existing)
                    .CurrentValues
                    .SetValues(schedule);
            }

            _db.SaveChanges();
        }

        public void Update(TeacherSchedule schedule)
        {
            var existing = _db.TeacherSchedules
                .FirstOrDefault(t => t.Id == schedule.Id);

            if (existing == null)
                throw new KeyNotFoundException("TeacherSchedule not found.");

            existing.TeacherId = schedule.TeacherId;
            existing.ClassId = schedule.ClassId;
            existing.Subject = schedule.Subject;
            existing.Hours = schedule.Hours;
            existing.Year = schedule.Year;
            _db.SaveChanges();
        }
    }
}
