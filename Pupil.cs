using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All
{    // Pupil Class inherits from Principal
    class Pupil : Principal
    {
        public string Gender { get; private set; }
        public string FaveGame {  get; private set; }
        public Pupil(string name, int age, string gender,string faveGame) : base(name, age,gender)
        {
            Gender = gender;
            FaveGame = faveGame;
        }
        public void DisplayPupilInfo(int index)
        {
            Console.WriteLine($"{index + 1}. Name: {Name}, Age: {Age}, Gender: {Gender}, Favorite Game: {FaveGame}");
        }
    }
}