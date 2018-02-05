using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Networking;
using ClashRoyale.Server.Packets.Messages.Server;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Client
{
    internal class AskForTopPlayersMessage : Message
    {
        public AskForTopPlayersMessage(Device Device, SCReader Reader) : base(Device, Reader)
        {
        }

        internal override void Process()
        {
            new TopPlayersMessage(Device).Send();
        }
    }
}