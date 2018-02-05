using System;
using System.Collections.Generic;
using ClashRoyale.Server.Packets.Commands.Server;
using ClashRoyale.Server.Packets.Messages.Client;

namespace ClashRoyale.Server.Packets
{
    internal class Factory
    {
        internal static Dictionary<short, Type> Messages = new Dictionary<short, Type>();
        internal static Dictionary<short, Type> Commands = new Dictionary<short, Type>();

        internal Factory()
        {
            LoadMessages();
            LoadCommands();
        }

        private static void LoadMessages()
        {
            Messages.Add(10101, typeof(LoginMessage));
            Messages.Add(10185, typeof(AskForTVContentMessage));
            Messages.Add(11149, typeof(AskForTopPlayersMessage));
            Messages.Add(11688, typeof(ClientCapabilitiesMessage));
            Messages.Add(14315, typeof(UpdateNameMessage));
            Messages.Add(18688, typeof(EndClientTurnMessage));
            Messages.Add(19860, typeof(RequestVisitedHomeMessage));
            Messages.Add(19863, typeof(NameChangeMessage));
            Messages.Add(19911, typeof(KeepAliveMessage));
        }

        private static void LoadCommands()
        {
            Commands.Add(278, typeof(NameChangeCallback));
        }
    }
}