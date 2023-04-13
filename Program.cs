using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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
        static void Main(string[] args)
        {
            Console.Clear();
            int hang = 40;
            int cot = 100;
            Random random = new Random();
            Map(hang, cot);
            bool isOver = false;
            int Xsnake= random.Next(1, hang/3);
            int Ysnake=random.Next(1, cot/3);
            int Xfood =random.Next(1, hang/3);
            int Yfood = random.Next(1, cot/3);
            
            Write(Xfood, Yfood, "+");
            while (!isOver)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Write(Ysnake, Xsnake, " ");
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        Xsnake++;
                        if (Xsnake == hang-1 )
                        {
                            isOver = true;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        Xsnake--;
                        if (Xsnake == 0)
                        {
                            isOver = true;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        Ysnake--;
                        if (Ysnake == 0)
                        {
                            isOver = true;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        Ysnake++;
                        if (Ysnake == cot-1 )
                        {
                            isOver = true;
                        }
                        break;
                    case ConsoleKey.Escape:
                        isOver = true;
                        break;
                }
                Write(Ysnake, Xsnake, "=");
            }               
        }
    }
}
