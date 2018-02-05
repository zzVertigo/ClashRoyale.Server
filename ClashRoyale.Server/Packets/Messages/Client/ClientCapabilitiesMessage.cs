using System.Diagnostics;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Client
{
    internal class ClientCapabilitiesMessage : Message
    {
        public ClientCapabilitiesMessage(Device Device, SCReader Reader) : base(Device, Reader)
        {
        }

        internal override void Decode()
        {
            Device.Ping = Reader.ReadVInt();
            Device.Interface = Reader.ReadString();
        }

        internal override void Process()
        {
            Debug.WriteLine("ClientCapabilities::Ping (" + Device.Player.HighID + "-" + Device.Player.LowID + ") - " +
                            Device.Ping + "ms\n");
        }
    }
}