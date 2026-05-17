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
    public class SqlAttendanceRepository : IAttendanceRepository
    {
        private readonly SchoolDbContext _db;

        public SqlAttendanceRepository(SchoolDbContext db)
        {
            _db = db;
        }

        public IReadOnlyList<Attendance> GetAll()
        {
            return _db.Attendances
                .Include(a => a.Student)
                .ToList();
        }

        public Attendance GetById(int id)
        {
            return _db.Attendances
                .Include(a => a.Student)
                .FirstOrDefault(a => a.Id == id);
        }
        public void Save(Attendance attendance)
        {
            if (attendance.Id == 0)
            {
                _db.Attendances.Add(attendance);
            }
            else
            {
                _db.Attendances.Update(attendance);
            }
            _db.SaveChanges();
        }
    }
}
