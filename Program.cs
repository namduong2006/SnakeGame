using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnakeGame
{
    internal class Program
    {       
        static void Write(int y, int x, string content)
        {
            Console.SetCursorPosition(y,x);
            Console.Write(content);
        }
        static void Map(int hang, int cot)
        {
            for (int i = 0; i < cot; i++)
            {
                for(int j = 0; j < hang; j++)
                {
                    if (i == 0 || i == cot - 1)
                    {
                        Write(i, j, "*");
                    }
                    if (j == 0 || j == hang - 1)
                    {
                        Write(i,j , "=");   
                    }
                }
            }
        }
        static void Snake(List<int> Xsnake, List<int> Ysnake)
        {
           for (int i = 0; i < Xsnake.Count; i++) 
           {
                Write(Xsnake[i], Ysnake[i], "="); 
           }
        }
        static void Food(int Xfood, int Yfood)
        {
            Write(Xfood, Yfood, "+"); 
        }
        static void MoveSnake(List<int> Xsnake, List<int>Ysnake,int direction)
        {
            for (int i = Xsnake.Count - 1; i > 0; i--) 
            {
                Xsnake[i] = Xsnake[i - 1];
                Ysnake[i] = Ysnake[i - 1];
            }
            switch (direction)
            {
                case 1:
                    Ysnake[0]--;
                    break;
                case 2:
                    Xsnake[0]--;
                    break;
                case 3:
                    Ysnake[0]++;
                    break;
                case 4:
                    Xsnake[0]++;
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int speed = 220;
            int hang = 30;
            int cot = 110;
            int xSnake = 10;
            int ySnake = 10;
            List<int> Xsnake = new List<int>() { xSnake };
            List<int> Ysnake = new List<int>() { ySnake };
            bool gameOver = false;
            int Xfood = random.Next(1, cot - 2);
            int Yfood = random.Next(1, hang - 2);
            int direction = 4;
            while (!gameOver)
            { 
                MoveSnake(Xsnake, Ysnake, direction);
                if (Xsnake[0] <= 1 || Xsnake[0] >= cot - 1)
                {
                    gameOver = true;
                }
                if (Ysnake[0] == 0 || Ysnake[0] == hang-1) 
                {
                    gameOver = true;
                }
                for (int i = 1; i < Xsnake.Count; i++)
                {
                    if (Xsnake[0] == Xsnake[i] && Ysnake[0] == Ysnake[i])
                    {
                        gameOver = true;
                    }
                }
                if (Xsnake[0] == Xfood && Ysnake[0] == Yfood)
                {
                    Xfood = random.Next(1, cot - 2);
                    Yfood = random.Next(1, hang - 2);
                    Xsnake.Add(Xsnake[Xsnake.Count - 1]);
                    Ysnake.Add(Ysnake[Ysnake.Count - 1]);
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (direction != 1) direction = 3;
                            break;
                        case ConsoleKey.UpArrow:
                            if (direction != 3) direction = 1;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (direction != 4) direction = 2;
                            break;
                        case ConsoleKey.RightArrow:
                            if (direction != 2) direction = 4;
                            break;
                        case ConsoleKey.Escape:
                            gameOver = true;
                            break;
                    }
                }
                Console.Clear();
                Map(hang, cot);
                Snake(Xsnake, Ysnake);
                Food(Xfood, Yfood);
                System.Threading.Thread.Sleep(speed);
            }
            if (gameOver == true)
            {
                Write(cot / 2, hang / 2, "GAME OVER :))");
                Console.ReadLine();
            }
        }
    }
}
