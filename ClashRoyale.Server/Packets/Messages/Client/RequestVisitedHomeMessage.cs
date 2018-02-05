using System;
using ClashRoyale.Server.Core;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Networking;
using ClashRoyale.Server.Packets.Messages.Server;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Client
{
    internal class RequestVisitedHomeMessage : Message
    {
        internal bool Exists;
        internal long UserID;

        public RequestVisitedHomeMessage(Device Device, SCReader Reader) : base(Device, Reader)
        {
        }

        internal override void Decode()
        {
            UserID = Reader.ReadInt64();
        }

        internal override void Process()
        {
            Exists = Resources.Players.ContainsKey(UserID);

            if (Exists)
                new VisitedHomeDataMessage(Device, Device.Player).Send();
            else
                Console.WriteLine("FUCK");
        }
    }
}