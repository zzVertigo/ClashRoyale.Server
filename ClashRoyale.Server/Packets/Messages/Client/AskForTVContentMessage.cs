using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Networking;
using ClashRoyale.Server.Packets.Messages.Server;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Client
{
    internal class AskForTVContentMessage : Message
    {
        private int ID;
        private int Type;

        public AskForTVContentMessage(Device Device, SCReader Reader) : base(Device, Reader)
        {
        }

        internal override void Decode()
        {
            Type = Reader.ReadVInt();
            ID = Reader.ReadVInt();
        }

        internal override void Process()
        {
            new RoyalTVContentMessage(Device, ID).Send();
        }
    }
}