using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tasks
{
	class task1
	{
		static void Main(string[] args)
		{
			Console.Write("Directory: ");
			string directory = Console.ReadLine();

			Console.Write("File Extension: ");
			string extencion = Console.ReadLine();

			foreach (FileInfo file in GetFilesList(directory, extencion))
			{
				Console.WriteLine(file.FullName);
			}

			Console.ReadLine();
		}

		public static ArrayList GetFilesList(string directoryName, string fileExtension)
		{
			ArrayList results = new ArrayList();
			ArrayList allFiles = new ArrayList();

			DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
			foreach (var file in directoryInfo.GetFiles())
			{
				if (Path.GetExtension(file.FullName) == fileExtension)
				{
					allFiles.Add(file);
				}
			}

			DateTime mostRecentTime = ((FileInfo)allFiles[0]).CreationTime;
			foreach (FileInfo file in allFiles)
			{
				if (file.CreationTime < mostRecentTime)
					mostRecentTime = file.CreationTime;
			}

			foreach (FileInfo file in allFiles)
			{
				if (file.CreationTime == mostRecentTime || (file.CreationTime < mostRecentTime.AddSeconds(10) && file.CreationTime > mostRecentTime))
				{
					results.Add(file);
				}
			}

			return results;
		}
	}
}
