using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_Bankomat
{
	internal class Menu
	{
		public List<string> inputMenu;
		int menuPoint = 0;
		public int setMenuPoint
		{
			get { return menuPoint; }
			set
			{
				if (value < 0) { menuPoint = 0; }
				else if (value > inputMenu.Count() - 1) { menuPoint = inputMenu.Count() - 1; }
				else { menuPoint = value; }
			}
		}
		public Menu() { }
		public Menu(ref List<string> inputList)
		{
			inputMenu = inputList;
		}
		public Menu(List<string> inputList)
		{
			inputMenu = inputList;
		}
		void PrintMenu(List<string> inputMenu, int inputMenuPoint, int X, int Y, ConsoleColor color, ConsoleColor defColor)
		{
			for (int i = 0; i < inputMenu.Count(); i++)
			{
				if (i == inputMenuPoint)
				{
					Console.BackgroundColor = color;
				}
				else
				{
					Console.BackgroundColor = defColor;
				}
				Console.CursorLeft = X; Console.CursorTop = Y + i;
				Console.Write(inputMenu[i]);
			}
			Console.ResetColor();
		}
		public int KlacKlac_CS_v1(int startX = 0, int startY = 0, ConsoleColor color = ConsoleColor.DarkGreen, ConsoleColor defColor = ConsoleColor.Black)
		{
			//int menuPoint = 0;
			ConsoleKey key = ConsoleKey.Spacebar;
			do
			{
				PrintMenu(inputMenu, menuPoint, startX, startY, color, defColor);
				key = Console.ReadKey(true).Key;
				if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
				{
					if (menuPoint < inputMenu.Count())
					{
						menuPoint++;
					}
					if (menuPoint == inputMenu.Count())
					{
						menuPoint = 0;
					}
				}
				if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
				{
					if (menuPoint >= 0)
					{
						menuPoint--;
					}
					if (menuPoint == -1)
					{
						menuPoint = inputMenu.Count() - 1;
					}
				}
				if (key == ConsoleKey.Enter)
				{
					return menuPoint;
				}
			} while (key != ConsoleKey.Escape);
			return -1;
		}
	}
}
