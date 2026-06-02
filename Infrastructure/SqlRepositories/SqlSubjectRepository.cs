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
    public class SqlSubjectRepository:ISubjectRepository
    {
        private readonly SchoolDbContext _db;

        public SqlSubjectRepository(SchoolDbContext db)
        {
            _db = db;
        }

        public IReadOnlyList<Subject> GetAll()
        {
            return _db.Subjects
                .Include(s => s.Teachers)
                .ToList();
        }

        public Subject? GetById(int id)
        {
            return _db.Subjects
                .Include(s => s.Teachers)
                .FirstOrDefault(s => EF.Property<int>(s, "Id") == id);
        }

        public void Save(Subject subject)
        {
            var existing = _db.Subjects
                .Include(s => s.Teachers)
                .FirstOrDefault(s => s.Type == subject.Type);

            if (existing == null)
            {
                _db.Subjects.Add(subject);
            }
            else
            {
                _db.Entry(existing)
                    .CurrentValues
                    .SetValues(subject);
                existing.Teachers = subject.Teachers;
            }

            _db.SaveChanges();
        }
    }
}
