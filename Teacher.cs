using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All
{
    class Teacher : Principal
    {
        public string Subject { get; set; }
        public string Gender { get; set; }
        public Teacher(string name, int age,string gender,string subject) : base(name, age,gender)
        {
            Subject = subject;
            Gender = gender;
        }
        public void DisplayTeacherInfo()
        {
            string title;

            Console.WriteLine("Teacher Information:");
            DisplayPrincipalInfo();
            {
                Console.Write($"Subject:{Subject}");
            }

        }
    }
}