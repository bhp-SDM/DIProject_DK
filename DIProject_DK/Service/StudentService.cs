using DIProject_DK.Interfaces;
using DIProject_DK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIProject_DK.Service
{
    public class StudentService
    {
        private IStudentRepository repository;

        public StudentService(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public void AddStudent(Student student)
        {
            repository.Add(student);
        }
    }
}
