using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaFighter
{
    public static class BattleA
    {
        public static int usualPosition = 0;
        //private static int  pDice=0,oDice=0;
        public static List<Character> characterList = new List<Character>();
        public static List<Character> characterList1 = new List<Character>();
        public static void StartFight()
        {
            

            Console.WriteLine("{0,-10} {1,-10} {2} {3}", characterList[0].Name, characterList[0].Rull, characterList[0].Strength, characterList[0].Health);
            GetOpponent();
            Console.WriteLine("{0,-10} {1,-10} {2} {3}", characterList1[0].Name, characterList1[0].Rull, characterList1[0].Strength, characterList1[0].Health);

            PrintField();

            bool endFlag = false;
            while (endFlag == false)
            {
                characterList[0].characterSpel();
                
                if (characterList[0].Lastposition >= 50)
                {
                    endFlag = true;
                    characterList[0].Health = 1;
                    Console.SetCursorPosition(0, usualPosition);
                    Console.WriteLine("{0,2}{1,5}\t\t{2,9}", characterList[0].CharacterDice, characterList[0].Health, characterList1[0].CharacterDice);
                    Console.ReadKey();
                }
                else
                {
                    characterList1[0].characterSpel();

                    if (characterList1[0].Lastposition >= 50)
                    {
                        endFlag = true;
                        Console.SetCursorPosition(0, usualPosition);
                        Console.WriteLine("{0,2}\t\t{1,9}\t  {2,5}", characterList[0].CharacterDice, characterList1[0].CharacterDice, (characterList1[0].Lastposition >= 50 ? 1 : 0));
                        Console.ReadKey();

                    }
                    else
                    {
                        Console.SetCursorPosition(0, usualPosition);
                        Console.WriteLine("{0,2}   {1,1}\t\t\t{2,1}    {3,1}", characterList[0].CharacterDice, characterList[0].Strength, characterList1[0].CharacterDice, characterList1[0].Strength);
                        //usualPosition = Console.CursorTop;

                        Console.SetCursorPosition(0, usualPosition + 1);
                        usualPosition = Console.CursorTop;

                        Console.WriteLine("roll Dice");
                        Console.ReadKey();

                    }

                }

                //Round.MoveAhead(pDice);

                //======

            }
            
            


            

            //characterList1 = new List<Character>();
        }
        public static void GetOpponent()
        {
            
            foreach (var item in characterList)
            {
                if (item.Rull.Contains("Opponent"))
                {
                    //Console.WriteLine("{0,-10} {1,-10} {2} {3}", item.Name, item.Rull, item.Strength, item.Health);
                    characterList1.Add(item);
                    characterList.Remove(item);
                    break;
                }
                    
                   
            }
        }
        public static void PrintField() 
        {

            #region SetConsoleWinow
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            Console.WindowHeight = 50;
            Console.WindowWidth = 100;
            #endregion

            
            Console.Clear();
            for (int k = 0; k < 8; k++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("      player                 Opponen ");
            Console.WriteLine("      [{0,5}]                [{1,-5}]", characterList[0].Name, characterList1[0].Name);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("[Dice Strength Health] [Dice Strength Health]");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("{0,7}{0,9}{2,14}{3,9}", characterList[0].Strength, characterList[0].Health, characterList1[0].Strength, characterList1[0].Health);
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
            Console.WriteLine();
            //Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
            Console.SetCursorPosition(0, usualPosition);
        }
    }


}
