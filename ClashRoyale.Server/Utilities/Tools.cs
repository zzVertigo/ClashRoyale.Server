using System;

namespace ClashRoyale.Server.Utilities
{
    internal class Tools
    {
        internal static string GetMessageDirection(short PacketID)
        {
            if (PacketID >= 20000 && PacketID < 30000)
                return "Server Message";
            if (PacketID >= 10000 && PacketID < 20000)
                return "Client Message";
            return "Invalid Message";
        }

        internal static long GetFullID(int HighID = 0, int LowID = 1, bool Binary = true)
        {
            if (Binary) return (HighID << 32) | (LowID & int.MaxValue);

            return 4294967297 * HighID - (HighID - 1);
        }

        internal static int GetHighID(long UserID)
        {
            return (int) (UserID >> 32);
        }

        internal static int GetLowID(long UserID)
        {
            return (int) (UserID & int.MaxValue);
        }

        internal static void GetHLID(long UserID)
        {
            var a1 = (int) (UserID >> 32);
            var a2 = (int) (UserID & uint.MaxValue);

            Console.WriteLine(a1 + "-" + a2);
        }
    }
}