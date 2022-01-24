using System;
using System.Diagnostics;
using System.IO;

namespace SegaSegaHaveALookAtHere
{
    public class Program
    {
        public const string argument = @".\crid_mod.exe -b 7F455149 -a 9DF55E68 -v ";
        public void Main()
        {
            Console.WriteLine("Enter MovieData location.");
            string? moviePath = Console.ReadLine();
            if (moviePath==null||moviePath.Equals(""))
            {
                moviePath = "";
            }

            string[] data = Directory.GetFiles(moviePath);

            Process crid = new Process();
            crid.StartInfo.FileName = "cmd";
            crid.StartInfo.UseShellExecute = false;
            crid.StartInfo.RedirectStandardInput = true;
            crid.StartInfo.RedirectStandardError = true;
            crid.StartInfo.CreateNoWindow = false;
            crid.Start();
            foreach (string movie in data)
            {
                crid.StandardInput.WriteLine(argument+movie);
            }
            crid.StandardInput.WriteLine("exit");
            crid.Close();
        }
    }
}
