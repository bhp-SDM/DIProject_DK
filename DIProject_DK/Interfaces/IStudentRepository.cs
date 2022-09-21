using DIProject_DK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIProject_DK.Interfaces
{
    public interface IStudentRepository
    {
        Student GetById(int id);
        List<Student> GetAll();

        void Add(Student s);
        void Update(Student s);
        void Delete(Student s);

    }
}
