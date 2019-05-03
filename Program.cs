using System;
using System.IO;
using System.IO.Compression;

namespace packer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Help();
                return;
            }

            switch (args[0].Trim('-').ToLower())
            {
                case "e":
                case "u":
                case "unzip":
                case "extract":
                    {
                        var folder = (args.Length == 3) ? args[2] : Path.GetFileNameWithoutExtension(args[1]);
                        Console.WriteLine($"Extracting {args[1]} to {folder}");
                        ZipFile.ExtractToDirectory(args[1], folder);
                    }
                    return;

                case "c":
                case "z":
                case "zip":
                case "compress":
                    {
                        var filename = (args.Length == 3) ? args[2] : Path.GetFileName(args[1]) + ".zip";
                        Console.WriteLine($"Creating {filename} from {args[1]}");
                        ZipFile.CreateFromDirectory(args[1], filename);
                    }
                    return;

                default:
                    {
                        Help();
                    }
                    return;
            }
        }

        private static void Help()
        {
            Console.WriteLine("Packer - Zip and Unzip files");
            Console.WriteLine("By Tom Laird-McConnell\n");

            Console.WriteLine("Packer --extract file.zip [folder]");
            Console.WriteLine("Packer --compress folder [file.zip]");
            return;
        }
    }
}