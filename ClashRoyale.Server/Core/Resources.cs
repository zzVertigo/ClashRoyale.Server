using ClashRoyale.Server.Files;
using ClashRoyale.Server.Logic.Slots;
using ClashRoyale.Server.Networking;
using ClashRoyale.Server.Packets;

namespace ClashRoyale.Server.Core
{
    internal class Resources
    {
        internal static AutoTimers AutoTimers;
        internal static CSV CSV;
        internal static Players Players;
        internal static TCPServer Gateway;
        internal static Factory Factory;

        internal static void Initialize()
        {
            CSV = new CSV();

            Players = new Players();

            AutoTimers = new AutoTimers();

            Factory = new Factory();
            Gateway = new TCPServer();
        }
    }
}