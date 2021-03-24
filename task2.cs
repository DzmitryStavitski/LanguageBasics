using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks.basics1
{
	class task2
	{
		public static void Main()
		{
			string[] firstNames = { "Alex", "Dima", "Kate", "Galina", "Ivan" };
			string[] secondNames = { "Dima", "Ivan", "Kate" };

			foreach (string name in MethodWithNoCollections(firstNames, secondNames))
			{
				Console.Write(name + " ");
			}

			Console.WriteLine();

			foreach (string name in MethodWithCollections(firstNames, secondNames))
			{
				Console.Write(name + " ");
			}

			Console.ReadLine();
		}

		public static String[] MethodWithNoCollections(string[] arr1, string[] arr2)
		{
			int j;
			int elementsNumber = arr1.Length;
			string[] diff = arr1;
			string[] difference;

			for (int i = 0; i < arr2.Length; i++)
			{
				for (j = 0; j < elementsNumber; j++)
				{
					if (diff[j].Equals(arr2[i]))
					{
						break;
					}
				}
				for (int k = j; k < elementsNumber - 1; k++)
					diff[k] = diff[k + 1];
				elementsNumber--;
			}
			difference = new string[elementsNumber];
			for (j = 0; j < elementsNumber; j++)
			{
				difference[j] = diff[j];
			}
			return difference;
		}

		public static IEnumerable<String> MethodWithCollections(string[] arr1, string[] arr2)
		{
			IEnumerable<String> diff = arr1.Except(arr2);
			return diff;
		}
	}
}
