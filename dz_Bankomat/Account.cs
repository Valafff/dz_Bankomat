using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_Bankomat
{
	internal class Account
	{
		// делегат принимает обьект, кот. стал источником события, и класс-сообщение
		public delegate void Account_delegate(object sender, AccountEventArgs e);

		public event Account_delegate EventAdd;
		public event Account_delegate EventWith;
		public event Account_delegate EventAddToMobile;
		public event Account_delegate EventPayToRequisites;

		public int Sum { get; set; }
		public int Sum_mobile { get; set; }

		public Account(int _sum = 0)
		{
			Sum = _sum;
		}

		// Положить деньги на счет
		public void Put(int _sum) 
		{
			if (_sum < 0) _sum *= -1;
			Sum += _sum;
			if (EventAdd != null)
			{
				EventAdd(this, new AccountEventArgs($"На счет поступило {_sum} у.е. Доступно {Sum} у.е", _sum));
			}
			//Обнуление списка событий!!!!!
			EventAdd = null;
		}

		// Снять деньги
		public void With(int _sum) 
		{
			if (_sum < 0) _sum *= -1;
			if (Sum >= _sum)
			{
				Sum -= _sum;
				if (EventWith != null)
				{
					EventWith(this, new AccountEventArgs($"Сумма {_sum} у.е снято со счета. Доступно {Sum} у.е" , _sum));
				}
				//Обнуление списка событий!!!!!
				EventWith = null;
			}
			else
			{
				EventWith(this, new AccountEventArgs($"Недостаточно денег на счету", _sum));
			}
		}
		//Положить деньги на телефон
		public void Put_Mobile(int _sum)
		{
			if (_sum < 0) _sum *= -1;
			if (Sum > _sum)
			{
				Sum -= _sum;
				if (EventAddToMobile != null)
				{
					EventAddToMobile(this, new AccountEventArgs($"SMS: Сумма {_sum} у.е. зачислено на телефон", _sum));
				}
				//Обнуление списка событий!!!!!
				EventAddToMobile = null;
			}
			else
			{
				EventAddToMobile(this, new AccountEventArgs($"Недостаточно денег на счету", _sum));
			}
		}
		//Перевести деньги по реквизитам
		public void Put_Requisites(int _sum)
		{
			if (_sum < 0) _sum *= -1;
			if (Sum > _sum)
			{
				Sum -= _sum;
				if (EventPayToRequisites != null)
				{
					EventPayToRequisites(this, new AccountEventArgs($"EMAIL: Перевод на сумму {_sum} успешно выполнен", _sum));
				}
				//Обнуление списка событий!!!!!
				EventPayToRequisites = null;	
			}
			else
			{
				EventPayToRequisites(this, new AccountEventArgs($"Недостаточно денег на счету", _sum));
			}
		}
		public void Balance()
		{
			Console.WriteLine($"На вашем сету: {Sum} у.е.");
		}
	}
	public class AccountEventArgs
	{
		public string MyMessage { get; set; }
		public int Sum { get; }
		public AccountEventArgs(string _mes, int _sum)
		{
			MyMessage = _mes;
			Sum = _sum;
		}
	}
}
