using System;
using System.Diagnostics;
using System.IO;

namespace zicat {
    public class Program
    {
        public static string ver = "Milestone 1";
        public static string dbPath = $"C:\\Users\\{Environment.UserName}\\zicat.db";
        public static ConfigFileInterpreter database;
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("     _           _   ");
            Console.WriteLine(" ___(_) ___ __ _| |_ ");
            Console.WriteLine("|_  / |/ __/ _` | __|");
            Console.WriteLine(" / /| | (_| (_| | |_ ");
            Console.WriteLine("/___|_|\\___\\__,_|\\__|");
            Console.WriteLine(ver);
            
            // If database path is not found
            if (!File.Exists(dbPath))
            {
                var lines = new List<string>
                {
                    "[pcparts]",
                    "ram-ddr4-8gb",
                    "ram-ddr4-8gb",
                    "sata-hdd",
                    "[cables]",
                    "micro-usb",
                    "micro-usb",
                    "usb-c",
                    "usb-c",
                    "usb-c"
                };

                File.WriteAllLines(dbPath, lines);
                Console.WriteLine("Template created. Please edit it with your catalog.");
            }
            
            database = new ConfigFileInterpreter(dbPath);
            Console.WriteLine("Database successfully read!");
            Console.WriteLine("\nCommands:");
            Console.WriteLine("'$v' ~ View database");
            Console.WriteLine("'$ed' ~ Edit database using vi");
            Console.WriteLine("'$q` ~ Exit app");
            Console.WriteLine("\nYou can also just type the name of an item in the database,\nand it will list which box its in and how many there are.");
            while (true)
            {
                Console.Write(">>>");
                string command = Console.ReadLine();
                if (command == "$v")
                {
                    Process.Start("C:\\Windows\\System32\\cmd.exe",$"/c C:\\Windows\\System32\\more.com {dbPath}").WaitForExit();
                }
                else if (command == "$ed")
                {
                    Process.Start("C:\\Windows\\System32\\cmd.exe",$"/c C:\\Windows\\System32\\notepad.exe {dbPath}").WaitForExit();
                    Console.WriteLine("Please restart zicat for changes to take effect.");
                }
                else if (command == "$q")
                {
                    Environment.Exit(0);
                }
                else
                {
                    try
                    {
                        var (box, quantity) = database.GetBoxAndQuantity(command);
                        Console.WriteLine($"The item is in box '{box}' and there are {quantity} of them.");
                    }
                    catch (InvalidDatabaseEntryException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}