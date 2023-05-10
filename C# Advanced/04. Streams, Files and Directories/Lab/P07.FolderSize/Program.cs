using System;
using System.Dynamic;
using System.IO;

namespace P07.FolderSize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using FileStream input = new FileStream(@"D:\SoftUniStreams\input.txt", FileMode.OpenOrCreate);
            using StreamWriter sw = new StreamWriter(@"D:\SoftUniStreams\output.txt");
            byte[] data = new byte[input.Length];

            var bytesPerFile = (int)Math.Ceiling(input.Length / 4.0);
            for(int i = 1; i <= 4; i++)
            {
                var buffer = new byte[bytesPerFile];
                input.Read(buffer);

                using FileStream writer = new FileStream($"Part-{i}.txt", FileMode.OpenOrCreate);
                writer.Write(buffer);
            }
        }
       
    }
}
