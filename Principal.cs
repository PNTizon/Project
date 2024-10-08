using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace All
{
    class Principal
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Gender { get; private set; }
        public Principal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public void DisplayPrincipalInfo()
        {
            string title;
            if (Gender.ToLower() == "male")
            {
                title = "Mr.";
            }
            else if (Gender.ToLower() == "female")
            {
                title = "Ms.";
            }
            else
            {
                title = " ";
            }
            Console.WriteLine($"{title}{Name}, Age: {Age}, Gender {Gender}");
        }
    }
}
