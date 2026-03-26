using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface IClassRepository
    {

        IReadOnlyList<Class> GetAll();
        Class GetById(int id);
        void Save(Class _class);

    }
}
