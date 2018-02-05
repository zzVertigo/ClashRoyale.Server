using System;
using System.Collections.Generic;
using System.Diagnostics;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Client
{
    internal class EndClientTurnMessage : Message
    {
        private uint Checksum;

        private byte[] Commands;
        private uint Count;
        private uint Tick;

        private List<Command> Historic;

        public EndClientTurnMessage(Device Device, SCReader Reader) : base(Device, Reader)
        {
        }

        internal override void Decode()
        {
            Tick = Reader.ReadVUInt();
            Checksum = Reader.ReadVUInt();
            Count = Reader.ReadVUInt();

            Debug.WriteLine("EndClientTurn::Decode - Tick: " + Tick + " | Checksum: " + Checksum + "\n");

            if (Count > 0)
                if (Count <= 512)
                {
                    Commands =
                        Reader.ReadBytes((int) (Reader.BaseStream.Length - Reader.BaseStream.Position));

                    this.Historic = new List<Command>((int) this.Count);
                }
        }

        internal override void Process()
        {
            if (Count > 0 && Count <= 512)
                using (var Reader = new SCReader(Commands))
                {
                    for (var i = 0; i < Count; i++)
                    {
                        var CommandID = (short) Reader.ReadVInt();

                        if (Factory.Commands.ContainsKey(CommandID))
                        {
                            Debug.WriteLine("EndClientTurn::Process - Handling command " + CommandID + "\n");

                            Command Command = Activator.CreateInstance(Factory.Commands[CommandID], Reader, this.Device, CommandID) as Command;
                            
                            Command.Decode();
                            Command.Process();

                            this.Historic.Add(Command);
                        }
                        else
                            Debug.WriteLine("EndClientTurn::Process - Unable to handle command " + CommandID + "\n");
                    }
                }
        }
    }
}