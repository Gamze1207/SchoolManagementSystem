using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.SqlRepositories
{
    public class SqlClassRepository : IClassRepository
    {
        private readonly SchoolDbContext _db;

        public SqlClassRepository(SchoolDbContext db)
        {
            _db = db;
        }

        public IReadOnlyList<Class> GetAll()
        {
            return _db.Classes
                .ToList();
        }
        public Class? GetById(int id)
        {
            return _db.Classes
                .FirstOrDefault(c => c.Id == id);
        }

        public void Save(Class classEntity)
        {
            var existingClass = _db.Classes
                .FirstOrDefault(c => c.Id == classEntity.Id);

            if (existingClass == null)
            {
                _db.Classes.Add(classEntity);
            }
            else
            {
                _db.Entry(existingClass)
                    .CurrentValues
                    .SetValues(classEntity);
            }

            _db.SaveChanges();

        }
    }
}
