using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks.basics1
{
	class task3
	{
		public static void Main()
		{
			Console.WriteLine(SelectСases(@"C:\Users\d.stavitsky\source\repos\tasks\tasks\basics1\TextFile1.txt"));
			Console.ReadLine();
		}

		private static List<String> ReturnStringsFromFile(string pathToTheFile)
        {
			List<String> stringsFromFile = new List<String>();

			StreamReader sr = new StreamReader(pathToTheFile, System.Text.Encoding.Default);
			string line;
			while ((line = sr.ReadLine()) != null)
			{
				stringsFromFile.Add(line);
			}
			sr.Close();

			return stringsFromFile;
		}


		private static string WriteStringsIntoTheFile(string filePath, List<String> strings)
        {
			FileStream filestream = new FileStream(filePath, FileMode.Create);
			StreamWriter streamwriter = new StreamWriter(filestream);
			foreach (string oneString in strings)
			{
				streamwriter.WriteLine(oneString);
			}
			streamwriter.Flush();
			streamwriter.Close();

			return filestream.Name;
		}

		public static string SelectСases(string pathToTheFile, int numberOfLines = 10)
		{
			List<String> stringsFromFile = ReturnStringsFromFile(pathToTheFile);

			List<String> randomStringFromFile = new List<String>();
			for (int i = 0; i < numberOfLines; i++)
			{
				int randomStringNumber = new Random().Next(1, stringsFromFile.Count());
				randomStringFromFile.Add(stringsFromFile[randomStringNumber]);
				stringsFromFile.RemoveAt(randomStringNumber);
			}
			randomStringFromFile.Insert(0, stringsFromFile[0]);

			FileInfo fileInf = new FileInfo(pathToTheFile);
			string directory = fileInf.DirectoryName;
			string fileName = Path.GetFileNameWithoutExtension(fileInf.Name);
			string fileExtension = fileInf.Extension;

			return WriteStringsIntoTheFile($"{directory}\\{fileName}_res{fileExtension}", stringsFromFile);
		}
	}
}
