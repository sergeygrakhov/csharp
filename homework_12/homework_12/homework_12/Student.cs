using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_12
{
    class Student
    {
        public String Name { get; set; }
        public Int32 Age { get; set; }
        public Dictionary<String, Int32> Ratings { get; set; }
        public IEnumerable<Int32[]> GetRatings()
        {
            yield return Ratings.Values.ToArray();
        }
        public void GetMediumRating()
        {
            Double _doubleMedium = default(Double);
            foreach (var item in GetRatings())
            {
                for (int i = 0; i < item.Length; i++)
                {
                    _doubleMedium += item[i];
                }
                _doubleMedium = _doubleMedium / item.Length;
            }
            Console.WriteLine(_doubleMedium);
        }
        public void AddSubject()
        {
            Boolean _flagCorrect = false;
            Int32 _iRate = default(Int32);
            Boolean _flagSubjectNew = false;
            String _SubjectName = null;
            while (!_flagSubjectNew)
            {
                Console.Write("Enter subject you want to add: ");
                _SubjectName = Console.ReadLine();
                try
                {
                    Ratings.Add(_SubjectName, default(Int32));
                    _flagSubjectNew = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("This subject exist");
                }
            }
            
            while (!_flagCorrect)
            {
                Console.Write("Enter rate for entered subject:");
                while (Int32.TryParse(Console.ReadLine(), out _iRate) == false)
                {
                    Console.Write("Not correct symbols in input...\r\n");
                }
                if ((_iRate > 12) || (_iRate < 1))
                {
                    Console.WriteLine("Not correct !!! (from 1 to 12)");
                }
                else
                {
                    _flagCorrect = true;
                }
            }
            Ratings[_SubjectName] = _iRate;

        }
    }
}