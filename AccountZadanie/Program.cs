using System.Security.Principal;

namespace Bank
{
	public class Program
	{
		static void test()
		{
			/* zablokowanie - odblokowanie konta
			*/
			var account = new Account("John");
			account.Block();
			Console.WriteLine(account.IsBlocked);
			account.Unblock();
			Console.WriteLine(account.IsBlocked);
		}
		static void Main(string[] args)
		{
			test();
		}
	}
}		