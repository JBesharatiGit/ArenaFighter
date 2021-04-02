using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace ArenaFighter
{
    class Program
    {
        public static int dice = 0;
        static void Main(string[] args)
        {
            //=====================================
            Character Plyer = new Character();
            Plyer.CreateCharacter("Ali");
            Plyer.Rull = "Player";
            Plyer.Line = 2;
            Plyer.MoveIcon = '#';
            BattleA.characterList.Add(Plyer);
            Plyer = new Character();
            for (int q = 0; q < 4; q++)
            {
                //Character Plyer = new Character();
                Plyer.CreateCharacter("Rabite"+q);
                Plyer.Rull = "Opponent";
                BattleA.characterList.Add(Plyer);
                Plyer.Line = 3;
                Plyer.MoveIcon = '?';
                Plyer = new Character();

            }
            BattleA.StartFight();
            //============================================
            #region SetConsoleWinow
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;
            #endregion

            person player = new person();
            Console.Write("Skriv in spelare namn.");
            player.Name=Console.ReadLine();
            //player.MoveIcon = "->*";
            player.MoveIcon = "J";
            player.setStrengthHealth();
            player.Line = 2;

            
            person opponent = new person();
            Console.Write("Skriv in spelare namn.");
            opponent.Name = Console.ReadLine();
            //opponent.MoveIcon = "->>*";
             opponent.MoveIcon = "H";
            opponent.setStrengthHealth();
            opponent.Line = 3;
            Personal personal = new Personal();
            BattleLog battle = new BattleLog();


            int usualPosition = 0;
            Console.Clear();
            for (int k = 0; k < 5; k++)
            {
                Console.WriteLine();
            }
                        
            Console.WriteLine("      player                 Opponen ");
            Console.WriteLine("      [{0,5}]                [{1,-5}]", player.Name, opponent.Name);
            Console.WriteLine("---------------------------------------------" );
            Console.WriteLine("[Dice Strength Health] [Dice Strength Health]");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("{0,7}{0,9}{2,14}{3,9}", player.Strength, player.Health, opponent.Strength, opponent.Health);
            //Console.WriteLine("{0,-5} {1,-15}      {2,-1}{3,-1}", player.Strength, player.Health, opponent.Strength, opponent.Health);
            //Console.WriteLine("               {0,-8}               {3,-10}", player.Health, opponent.Health);
            //Console.WriteLine(" \t{0,-10}\t{1,-10}",player.Name,opponent.Name);
            //Console.WriteLine("PLAYER {0,-10}\t{1,-10}", player.Strength, opponent.Strength);
            //Console.WriteLine("OPPNENT   {0,-10}\t{1,-10}", player.Health, opponent.Health);
            Console.WriteLine("----------------------------------------------");


            usualPosition = Console.CursorTop;
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("-");
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("-");
            Console.SetCursorPosition(15, 2);
            Console.WriteLine("*");
            Console.SetCursorPosition(15, 3);
            Console.WriteLine("*");

            Console.SetCursorPosition(25, 2);
            Console.WriteLine("+");
            Console.SetCursorPosition(25, 3);
            Console.WriteLine("+");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine(";");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine(":");

            Console.SetCursorPosition(0, usualPosition );
            Console.WriteLine("roll Dice");
            Console.ReadKey();

            //for (int j = 0; j < 10; j++)
            int nyckel = 1;
            bool endFlag = false;
            while(endFlag==false)
            {
                player.release();
                opponent.release();
                player.RollDice();
                opponent.RollDice();
                
                Console.SetCursorPosition(0, usualPosition);
                Console.WriteLine("{0,2}\t\t{1,9}", player.Dice,opponent.Dice);

                player.moveAhead(player.Dice);
                player.changestrength();
                
                if (player.LastPosition >= 50)
                {
                    endFlag = true;
                    Console.SetCursorPosition(0, usualPosition);
                    Console.WriteLine("{0,2}{1,5}\t\t{2,9}", player.Dice, (player.LastPosition >= 26 ? 1 : 0), opponent.Dice);
                }
                else
                {
                    opponent.moveAhead(opponent.Dice);
                    opponent.changestrength();
                    if (opponent.LastPosition >= 50)
                    {
                        endFlag = true;
                        Console.SetCursorPosition(0, usualPosition);
                        Console.WriteLine("{0,2}\t\t{1,9}{2,5}", player.Dice, opponent.Dice, (opponent.LastPosition >= 26 ? 1 : 0));

                    }
                    else
                    {
                        Console.SetCursorPosition(0, usualPosition + 1);
                        usualPosition = Console.CursorTop;

                        Console.WriteLine("roll Dice");
                        Console.ReadKey();

                    }

                }
                
    

                personal.playerDice = player.Dice; personal.playerStrength = player.Strength; personal.playerHealth = player.Health;
                personal.opponentDice = opponent.Dice; personal.opponentStrength = opponent.Strength; personal.opponentHealth = opponent.Health;
                battle.PersonLog. Add(nyckel, personal);
                nyckel++;
                

            }
            //foreach (var entry in battle)
            //{
            //    // do something with entry.Value or entry.Key
            //}
            Console.ReadKey();
        }

   
    }
    public class person
    {
        #region properties
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }
        public string MoveIcon { get; set; }
        public int Dice { get; set; }
        public int Line { get; set; }
        public int LastPosition { get { return _lastPosition; } /*set { _lastPosition = value; }*/ }

        

        private Random rnd = new Random();
        private int _lastPosition = 0;

        #endregion

        #region Methods
        public void moveAhead(int distance)
        {
            int i = _lastPosition;
            while (i < _lastPosition + distance)
            {
                if (i > 0)
                {
                    Console.SetCursorPosition(i - 1, Line);
                    Console.WriteLine(" ");
                }

                mydelay(200);
                Console.SetCursorPosition(i, Line);
                Console.WriteLine(MoveIcon);
                mydelay(200);
                i++;
            }
            _lastPosition = i;

            //PersonLog.Add((Dice + ',' + Strength).ToString());

        }
        public void moveBack(int distance)
        {
            int i = _lastPosition;
            while (i > _lastPosition + distance)
            {
                i--;
                if (i > 0)
                {
                    Console.SetCursorPosition(i + 1, Line);
                    Console.WriteLine(" ");
                }

                mydelay(50);
                Console.SetCursorPosition(i, Line);
                Console.WriteLine(MoveIcon);
                mydelay(50);
                //i++;
            }
            _lastPosition = i;


        }
        public void RollDice()
        {
            Dice = rnd.Next(1, 7);
        }
        public void setStrengthHealth()
        {
            Strength = rnd.Next(1, 6);
            Health = rnd.Next(1, 6);
        }
        public void changestrength()
        {
            switch (_lastPosition)
            {
                case 11:
                    mydelay(400);
                    Strength = -2;
                    moveBack(-2);
                    break;
                case 16:
                    mydelay(400);
                    Strength = 4;
                    moveAhead(4);
                    break;
                case 26:
                    mydelay(400);
                    Strength = 2;
                    moveAhead(2);
                    break;
                case 50:
                    break;
                default:
                    break;
            }
            //PersonLog.Add((Dice + ',' + Strength).ToString());
        }
        public static void mydelay(double seconds)
        {
            DateTime d = DateTime.Now.AddMilliseconds(seconds);
            do { } while (DateTime.Now < d);
        }
        public void printStuff()
        {

        }
        public void release()
        {
            Dice = 0;
            Strength = 0;
            Health = 0;
        }
         #endregion
    }
    public class Personal 
    {

        public int playerDice, playerStrength, playerHealth, opponentDice, opponentStrength, opponentHealth;
    }
    public class BattleLog
    {
        

        //public int playerDice, playerStrength, playerHealth, opponentDice, opponentStrength, opponentHealth;
        public Dictionary<int, Personal> PersonLog = new Dictionary<int, Personal>();
    }
}
