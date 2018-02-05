using System;
using System.Drawing;
using System.Reflection;
using System.Threading;
using ClashRoyale.Server.Core;
using ClashRoyale.Server.Database;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server
{
    internal class Program
    {
        private static void Main()
        {
            Console.Title = "Clash Royale Server © 2018 || Players: " + MySQL.GetSeed("Players", "UserID");

            Console.SetOut(new Prefixed());
            // Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            Colorful.Console.WriteWithGradient(@"
                                 ________           __       ____                    __
                                / ____/ /___ ______/ /_     / __ \____  __  ______ _/ /__
                               / /   / / __ `/ ___/ __ \   / /_/ / __ \/ / / / __ `/ / _ \
                              / /___/ / /_/ (__  ) / / /  / _, _/ /_/ / /_/ / /_/ / /  __/
                              \____/_/\__,_/____/_/ /_/  /_/ |_|\____/\__, /\__,_/_/\___/
                                                                     /____/
            ", Color.BlueViolet, Color.Blue, 14);

            Console.ForegroundColor = ConsoleColor.White;

            string Hexa =
                "00 00 3F 01 01 00 00 00 00 00 00 02 00 00 01 00 00 00 00 0E 00 00 02 01 00 00 01 8F 01 00 00 02 01 00 00 01 8E 01 00 00 01 00 00 00 00 04 00 00 01 00 00 00 00 00 00 00 7F 7F 7F 9A F9 82 A5 0B 01 00 0D 83 09";

            using (SCReader Reader = new SCReader(Hexa.HexaToBytes()))
            {
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());

                Console.WriteLine("ID: " + Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
         
                Console.WriteLine("ID: " + Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());
                Console.WriteLine(Reader.ReadVInt());


                Console.WriteLine(BitConverter.ToString(Reader.ReadFully()).Replace("-", " "));
            }

            Console.WriteLine();
            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Name + " is now starting...\n");

            Resources.Initialize();

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();

            Thread.Sleep(-1);
        }
    }
}