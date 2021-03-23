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
		public static string selectСases(string pathToTheFile, int numberOfLines = 10)
		{
			List<String> stringsFromFile = new List<String>();

			StreamReader sr = new StreamReader(pathToTheFile, System.Text.Encoding.Default);
			string line;
			while ((line = sr.ReadLine()) != null)
			{
				stringsFromFile.Add(line);
			}
			sr.Close();

			List<String> randomStringFromFile = new List<String>();
			for (int i = 0; i < numberOfLines; i++)
			{
				int randomStringNumber = new Random().Next(1, stringsFromFile.Count());
				randomStringFromFile.Add(stringsFromFile[randomStringNumber]);
				stringsFromFile.RemoveAt(randomStringNumber);
			}

			FileInfo fileInf = new FileInfo(pathToTheFile);
			string directory = fileInf.DirectoryName;
			string fileName = Path.GetFileNameWithoutExtension(fileInf.Name);
			string fileExtension = fileInf.Extension;

			FileStream filestream = new FileStream(directory + "\\" + fileName + "_res" + fileExtension, FileMode.Create);
			StreamWriter streamwriter = new StreamWriter(filestream);
			streamwriter.WriteLine(stringsFromFile[0]);
			foreach (string oneString in randomStringFromFile)
			{
				streamwriter.WriteLine(oneString);
			}
			streamwriter.Flush();
			streamwriter.Close();

			return filestream.Name;
		}
	}
}
