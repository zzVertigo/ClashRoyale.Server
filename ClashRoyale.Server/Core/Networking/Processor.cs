using System;
using System.Diagnostics;
using ClashRoyale.Server.Core;
using ClashRoyale.Server.Packets;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Networking
{
    internal static class Processor
    {
        /// <summary>
        ///     Sends the specified message.
        /// </summary>
        /// <param name="Message">The message.</param>
        internal static void Send(this Message Message)
        {
            Message.Encode();
            Message.Encrypt();

            Debug.WriteLine("Processor::Send (" + Message.Device.Player.HighID + "-" + Message.Device.Player.LowID +
                            ") - Sending packet " + Message.PacketID + " (" + Message.GetMessageType() + ")");
            Debug.WriteLine("Processor::Send - Message Type: " + Tools.GetMessageDirection(Message.PacketID) + "\n");

            Resources.Gateway.Send(Message);

            Message.Process();
        }

        internal static Command Handle(this Command Command)
        {
            Console.WriteLine("Sending: " + Command.Identifier);

            Command.Encode();
            return Command;
        }
    }
}