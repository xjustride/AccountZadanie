using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
	public class Account : IAccount
	{
		public string Name { get; }
		public decimal Balance { get; private set; }
		public bool IsBlocked { get; private set; }

		public Account(string name, decimal balance = 0)
		{
			if (name == null) { throw new ArgumentOutOfRangeException("Name is null"); }

			Name = name.Trim();

			if (Name.Length < 3) { throw new ArgumentException(); }

			Balance = Math.Round(balance, 4);
			if (Balance < 0) { throw new ArgumentOutOfRangeException(); }
		}


		

		public void Block()
		{
			IsBlocked = true;
		}

		public void Unblock()
		{
			IsBlocked = false;
		}

		public bool Deposit(decimal amount)
		{
			if (amount < 0)
			{
				return false;
			}
			else if (IsBlocked == true)
			{
				return false;
			}
			else
			{
				Balance += amount;
				return true;
			}
		}

		public bool Withdrawal(decimal amount)
		{
			if (amount <= 0)
			{
				return false;
			}
			else if (IsBlocked == true)
			{
				return false;
			}
			else if (Balance < amount)
			{
				return false;
			}
			else
			{
				Balance -= amount;
				return true;
			}
		}

		public override string ToString()
		{

			if (IsBlocked)
			{
				return $"Account name: {Name}, balance: {Balance.ToString("F", CultureInfo.InvariantCulture)}, blocked";
			}
			else
			{
				return $"Account name: {Name}, balance: {Balance.ToString("F", CultureInfo.InvariantCulture)}";
			}
		}
	}
}