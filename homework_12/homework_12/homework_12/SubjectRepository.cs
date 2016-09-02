using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_12
{
    class SubjectRepository
    {
        public List<Subject> Subjects { get; set; }
        
        public SubjectRepository()
        {
            Subjects = new List<Subject>
            {
                new Subject() {Name = "Math" , Rating = GetRandaomRating() },
                new Subject() {Name = "English", Rating = GetRandaomRating() },
                new Subject() {Name = "Sport", Rating = GetRandaomRating() },
                new Subject() {Name = "Chemistry", Rating = GetRandaomRating() },
                new Subject() {Name = "Algebra", Rating = GetRandaomRating() },
                new Subject() {Name = "Geometry", Rating = GetRandaomRating() },
            };
        }
        private Int32 GetRandaomRating()
        {
            Random _iRandom = new Random();
            Console.WriteLine(_iRandom.Next(1,13));
            return _iRandom.Next(1, 13);
        }
    }
}
