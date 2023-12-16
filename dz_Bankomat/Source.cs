using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace dz_Bankomat
{
	internal class Source
	{
		int index;
		int quit_index;
		int sum;

		public Menu terminal = new Menu(new List<string> { "Выдача денег", "Зачисление денег на карту", "Пополнение мобильного телефона", "Оплата по реквизитам", "Вывод баланса на экран", "Завершить обслуживание" });
		public Account someAccount = new Account(5000);
		public void SetMenuPoint(int setMenuPoint)
		{
			terminal.setMenuPoint = setMenuPoint;
		}
		public void SetQuitIndex(int arg_quitIndex = -1)
		{
			if (arg_quitIndex == -1) { quit_index = terminal.inputMenu.Count - 1; }
			else
			{
				quit_index = arg_quitIndex;
			}
		}
		int getIndex()
		{
			return terminal.KlacKlac_CS_v1();
		}
		void Cleaner()
		{
			SetCursorPosition(0, 10);
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 60; j++)
				{
					Write(" ");
				}
				WriteLine();
			}
		}
		public void Terminal()
		{
			quit_index = terminal.inputMenu.Count-1;

			do
			{
				index = getIndex();
				switch (index)
				{
					case 0:
						Cleaner();
						SetCursorPosition(0, 10);
						Write("Какую сумму вы хотите снять? ");
						sum = Convert.ToInt32(ReadLine());
						someAccount.EventWith += (object sender, AccountEventArgs e) => { WriteLine($"Сумма транзакции: {e.Sum} у.е"); WriteLine(e.MyMessage); };
						someAccount.With(sum);
						break;
					case 1:
						Cleaner();
						SetCursorPosition(0, 10);
						Write("Какую сумму вы хотите положить? ");
						sum = Convert.ToInt32(ReadLine());
						someAccount.EventAdd += (object sender, AccountEventArgs e) => { WriteLine($"Сумма транзакции: {e.Sum} у.е"); WriteLine(e.MyMessage); };
						someAccount.Put(sum);
						break;
					case 2:
						Cleaner();
						SetCursorPosition(0, 10);
						Write("На какую сумму вы хотите пополнить счет? ");
						sum = Convert.ToInt32(Console.ReadLine());
						someAccount.EventAddToMobile += (object sender, AccountEventArgs e) => { WriteLine($"Сумма транзакции: {e.Sum} у.е"); WriteLine(e.MyMessage); };
						someAccount.Put_Mobile(sum);
						break;
					case 3:
						Cleaner();
						SetCursorPosition(0, 10);
						Write("Какую сумму вы хотите перевести? ");
						sum = Convert.ToInt32(Console.ReadLine());
						someAccount.EventPayToRequisites += (object sender, AccountEventArgs e) => { WriteLine($"Сумма транзакции: {e.Sum} у.е"); WriteLine(e.MyMessage); };
						someAccount.Put_Requisites(sum);
						break;
					case 4:
						Cleaner();
						SetCursorPosition(0, 10);
						someAccount.Balance();
						break;
					default:
						break;
				}
			} while (index!= quit_index);
            Console.WriteLine();
        }

	}
}
