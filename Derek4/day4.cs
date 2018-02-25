using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derek4
{
	public class Customer//默认为private，要想其他class可以访问需要加public
	{
		//attributes
		private string name;
		private string address;
		private string passportnumber;
		private DateTime DateOfBirth;

		//constructor
		public Customer(string Name, string Address, string PassNum)
		{
			name = Name;
			address = Address;
			passportnumber = PassNum;
		}
		public Customer(string name, string address, string passnumber, DateTime dob)
			: this(name, address, passnumber)
		{
			DateOfBirth = dob;
		}
		public Customer(string name, string address, string passnumber, int age)
			: this(name, address, passnumber)
		{
			DateOfBirth = new DateTime(DateTime.Now.Year - age, 1, 1);
		}
		public Customer() : this("No name", "No address", "No passportnumber", new DateTime(1980, 1, 1))
		{ }

		//properties
		public string Name
		{
			get
			{
				return name;
			}
		}
		public string Address
		{
			get
			{
				return address;
			}
			set
			{
				address = value;
			}
		}
		public string PassportNum
		{
			get
			{
				return passportnumber;
			}
			set
			{
				passportnumber = value;
			}
		}
		public int Age
		{
			get
			{
				return DateTime.Now.Year - DateOfBirth.Year;//Attention!
			}
		}

		//Methods
		public string Show()
		{
			string m = string.Format
				("Name: {0}\n Address: {1}\n Passportnumber: {2}\nDate of birth: {3}", name, address, passportnumber, DateOfBirth);
			return m;
		}
	}
	public class Bankaccount
	{
		//attibutes
		private string accountNum;
		private Customer accountholder;
		private double balance;
		double interestRate;

		//constructor
		public Bankaccount(string Num, Customer Holder, double Bal, double Rate)
		{
			accountNum = Num;
			accountholder = Holder;
			balance = Bal;
			InterestRate = Rate;
		}
		public Bankaccount() : this("000", new Customer(), 0, 0)
		{ }

		//property
		public string AccountNum
		{
			get
			{
				return accountNum;
			}
		}
		public Customer Accountholder
		{
			get
			{
				return accountholder;
			}
			set
			{
				accountholder = value;//保留空间，此时没有值
			}
		}
		public double Balance
		{
			get
			{
				return balance;
			}
		}
		public double InterestRate
		{
			get
			{
				return interestRate;
			}
			set
			{
				interestRate = value;
			}
		}

		//method--->withdraw,deposit,transfer
		public void Deposit(double amount)
		{
			balance = balance + amount;
		}
		public bool Withdraw(double amount)
		{
			if (amount < balance)
			{
				balance = balance - amount;
				return (true);
			}
			else
			{
				Console.Error.WriteLine("Unsuccessful");
				return false;
			}
		}
		public bool TransferTo(double amount, Bankaccount another)
		{
			if (Withdraw(amount))
			{
				another.Deposit(amount);
				return true;
			}
			else
			{
				Console.Error.WriteLine("Unsuccesful");
				return false;
			}
		}
		public double CaculateInterest()
		{
			double interest = this.balance * 0.01;
			return interest;
		}
		public void CreditInterest()
		{
			double a = CaculateInterest();
			Deposit(a);

		}

		public string Show()
		{
			string m = string.Format
				("[Account:accountnumber={0},accountholder={1},balance={2}]",
				AccountNum, Accountholder, Balance);
			return m;
		}
    }
		//使用继承的方法完成另两种method。
		public class CurrentAccount : Bankaccount
		{
			//constructor
			public CurrentAccount(string Num, Customer Holder, double bal, double Rate)
				: base(Num, Holder, bal, Rate)
			{ }
			public new double CaculateInterest()
			{
				double interest = this.Balance * 0.025;
				return interest;

			}
			/*			public new void creditInterest()
						{
							double a = CaculateInterest();
							Deposit(a);
						}*/                         //因为和bankaccount里的creditInterest一样，故不用new creditinterest账户。
			public string show()
			{
				string m = string.Format
				("[CurrentAccount:accountnumber={0},accountholder={1},balance={2}]",
				AccountNum, Accountholder, Balance);
				return m;
			}
		}
		public class OverdrafAccount:Bankaccount
		{
			public OverdrafAccount(string Num, Customer Holder, double bal, double Rate)
				: base(Num, Holder, bal, Rate)
			{ }
			public new double CaculateInterest()
			{
			double interest;
			   if (Balance>0)
			{
				interest = this.Balance * 0.0025;
			}
			   else
			{
				interest = this.Balance *  0.06;
			}
				
				return interest;

			}
			public new void  CreditInterest()
			{
			double a = CaculateInterest();
			
				Deposit(a);
			    

			}                      
			public string show()
			{
				string m = string.Format
				("[OverdrafAccount:\naccountnumber={0},\naccountholder={1},\nbalance={2}]",
				AccountNum, Accountholder.Show(), Balance);
				return m;
			}
		}
	
	public class Test
		{
			 static void Main()
			{
				Customer a = new Customer("Shanice", "NUS ISS", "A01802b");
				OverdrafAccount k = new OverdrafAccount("10001", a, -600, 0);
				k.CreditInterest();
				Console.WriteLine(k.show());

			}
		}
	
}
