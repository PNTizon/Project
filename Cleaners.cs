using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Inheritance_AT
{
    internal class Cleaners
    {
        public static bool IsValidName(string name)
        {
            bool isValid = false;
            try
            {
                isValid = !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[A-Z][a-zA-Z\s]");
            }
            catch { isValid = false; }
            return isValid;
        }
        public static string GetName(string prompt)
        {
            bool isValid = false;
            string name;
            do
            {
                Console.Write(prompt);
                name = Console.ReadLine();
                if (Cleaners.IsValidName(name))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid name. Please enter a name containing only letters and spaces.");
                }
            } while (!isValid);
            return name;
        }
        public static int GetNumPil(string prompt, bool canBeNegative = false)
        {
            int age = 0;
            bool isValid = false;
            do
            {
                Console.Write(prompt);
                isValid = int.TryParse(Console.ReadLine(), out age);
                if (!canBeNegative && age <= 0)
                {
                    isValid = false;
                    Console.WriteLine("Age must can't be a negative number number.");
                }
                else if (age >= 20)
                {
                    isValid = false;
                    Console.WriteLine("Age must be less than 20 years old. Please try again.");
                }
            } while (!isValid);
            return age;
        }
        public static int GetNumTeach(string prompt, bool canBeNegative = false)
        {
            int age = 0;
            bool isValid = false;
            do
            {
                Console.Write(prompt);
                isValid = int.TryParse(Console.ReadLine(), out age);
                if (!canBeNegative && age <= 0)
                {
                    isValid = false;
                    Console.WriteLine("Age can't be a negative number number.");
                }
                else if (age >= 65)
                {
                    isValid = false;
                    Console.WriteLine("Teacher's age must not above 65 years old. Please try again.");
                }
            } while (!isValid);
            return age;
        }
        public static string GetGender(string prompt)
        {
            bool isValid = false;
            string gender;
            do
            {
                Console.Write(prompt);
                gender = Console.ReadLine().ToLower();

                if (gender == "male" || gender == "female" || gender == "m" || gender == "f")
                {
                    isValid = true; 
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'male', 'female', 'm', or 'f'.");
                }
            } while (!isValid);

            return gender;
        }
        public static string NumPils(string prompt)
        {
            string subject;
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    subject = Console.ReadLine();

                    if (int.TryParse(subject, out _))
                    {
                        throw new Exception ("Please enter a valid subject name, not a number.");
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return subject;
        }
    }
}
