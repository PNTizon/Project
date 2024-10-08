using Inheritance_AT;
using System;


namespace All
{
    class Program
    {
        public static void Main(string[] args)
        {
            string teacherName,teachSub,teacherGender, faveGame,again;
            int teacherAge,numPupils; ;
            do
            {

                Console.WriteLine("Press any key to start...");
                Console.ReadKey();
                
                Console.Clear();

                teacherName = Cleaners.GetName("Enter the teacher's name: ");

                teacherAge = Cleaners.GetNumTeach("Enter the teacher's age: ");

                teacherGender = Cleaners.GetGender("Enter teacher's gender: ");

                teachSub = Cleaners.NumPils("What subject do you teach? ");

                Console.Write("How many pupils does the teacher have? ");
                numPupils = Convert.ToInt32(Console.ReadLine());

                Teacher teacher = new Teacher(teacherName, teacherAge,teacherGender,teachSub);
                PupilGroup pupilGroup = new PupilGroup(teacher, numPupils);
                pupilGroup.EnterPupilDetails();

                Console.WriteLine();
                teacher.DisplayTeacherInfo();
                Console.WriteLine();
                pupilGroup.DisplayPupilNames();

                Console.WriteLine();
                Console.WriteLine("Do you want to perform another calculation? (y/n) : ");
                again = Console.ReadLine().ToLower();
                Console.Clear();

            } while (again == "y");
            Console.WriteLine("Thank you for using!");
        }
    }
    class PupilGroup
    {
        private Pupil[] pupils;
        private Teacher teacher;

        public PupilGroup(Teacher teacher, int numberOfPupils)
        {
            this.teacher = teacher;
            pupils = new Pupil[numberOfPupils];
        }
        public void EnterPupilDetails()
        {
            string pupilName, pupilGender, faveGame;
            int pupilAge;

            for (int i = 0; i < pupils.Length; i++)
            {
                pupilName = Cleaners.GetName($"Enter the name of pupil {i + 1}: ");

                pupilGender = Cleaners.GetGender("Enter pupil's gender: ");

                pupilAge = Cleaners.GetNumPil("Enter pupil's age: ");

                faveGame = Cleaners.GetName("Enter pupil's favorite game:");

                pupils[i] = new Pupil(pupilName, pupilAge, pupilGender,faveGame);
            }
        }
        public void DisplayPupilNames()
        {
            Console.WriteLine("\nList of pupils:");
            for (int i = 0; i < pupils.Length; i++)
            {
                pupils[i].DisplayPupilInfo(i);
            }
        }
    }
}