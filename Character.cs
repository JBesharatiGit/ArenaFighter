using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    public class Character//:Round
    {
        public int _lastPosition = 0;
        public int _strength = 0;
        public string Name { get; set; }
        public string Rull { get; set; }
        public int Strength { get { return _strength; } set { _strength = value; } }
        public int Health { get; set; }
        public int Line { get; set; }
        public char MoveIcon { get; set; }
        public int CharacterDice { get; set; }
        public int Lastposition { get { return _lastPosition; } set { _lastPosition = value; } }

        public void CreateCharacter(string name) 
        {
            Name = name;
            Strength =  Round.RollDice();
            Health = Round.RollDice();
        }
        public void characterSpel() 
        {
            release();
            CharacterDice = Round.RollDice();
            Round.MoveAhead(Line, MoveIcon, CharacterDice, ref _lastPosition);
            Round.Changestrength(Line, MoveIcon, ref _strength, ref _lastPosition);

        }
        public void release()
        {
            CharacterDice = 0;
            Strength = 0;
            Health = 0;
        }
    }
}
