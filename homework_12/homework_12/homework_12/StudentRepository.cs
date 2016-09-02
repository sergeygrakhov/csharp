using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_12
{
    class StudentRepository
    {
        public List<Student> Students { get; set; }
        public StudentRepository()
        {
            Students = new List<Student>
            {
                new Student() {Name = "Peter", Age = 10, SubjectRatings = new SubjectRepository() },
                new Student() {Name = "John", Age = 20, SubjectRatings = new SubjectRepository() },
                new Student() {Name = "Nik", Age = 105, SubjectRatings = new SubjectRepository() },
                new Student() {Name = "Harold", Age = 20, SubjectRatings = new SubjectRepository() },
                new Student() {Name = "Oleg", Age = 30, SubjectRatings = new SubjectRepository() },
                new Student() {Name = "Dmitry", Age = 42, SubjectRatings = new SubjectRepository() },
                new Student() {Name = "Ivan", Age = 13, SubjectRatings = new SubjectRepository() },
            };
        }
        // public IEnumerable<Student> GetEnumerator()
        //{
        //    foreach (var item in Students)
        //    {
        //        yield return item;
        //    }
        //}
    }
}
