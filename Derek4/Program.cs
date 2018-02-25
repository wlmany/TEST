using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derek4
{
	class Animal
	{
		static void Main(string[] args)
		{
		}
	}
	class Cat:Animal
	{
		public void q()
		{ }
	}
	class test
	{
		public static void Main()
		{
			Animal v = new Animal();
			Cat w = new Cat();
			Animal v2 = w;
			Cat w2 = (Cat)v2;//cat can = animal--> cat's area widening;but animal can't= cat.--->will narrow.
			w2.q();//can't v2.q;because q is a method of animal.
		}
	}
}
