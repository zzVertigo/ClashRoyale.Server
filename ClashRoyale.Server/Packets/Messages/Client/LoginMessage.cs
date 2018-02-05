using System;
using System.Net;
using ClashRoyale.Server.Core;
using ClashRoyale.Server.Logic;
using ClashRoyale.Server.Managers;
using ClashRoyale.Server.Networking;
using ClashRoyale.Server.Packets.Messages.Server;
using ClashRoyale.Server.Utilities;

namespace ClashRoyale.Server.Packets.Messages.Client
{
    internal class LoginMessage : Message
    {
        internal int Build;

        internal int Major;

        internal string Masterhash;
        internal int Minor;

        internal string Token;
        internal long UserID;

        public LoginMessage(Device Device, SCReader Reader) : base(Device, Reader)
        {
        }

        internal override void Decode()
        {
            UserID = Reader.ReadInt64();

            Token = Reader.ReadString();

            Major = Reader.ReadVInt();
            Minor = Reader.ReadVInt();
            Build = Reader.ReadVInt();

            Masterhash = Reader.ReadString();

            Reader.ReadInt32();

            Device.AndroidID = Reader.ReadString();

            Reader.ReadString();

            Device.Model = Reader.ReadString();
            Device.OpenUDID = Reader.ReadString();
            Device.OSVersion = Reader.ReadString();
            Device.isAndroid = Reader.ReadBoolean();

            Reader.ReadInt32();

            Reader.ReadString();
            Reader.ReadString();
        }

        internal override void Process()
        {
            if (UserID == 0)
            {
                this.Device.Player = Resources.Players.CreatePlayer(Device, 0, true);

                if (this.Device.Player != null)
                {
                    Login();
                }
                else
                {
                    Console.WriteLine("Fuck your self");
                }
            }
            else
            {
                try
                {
                    Device.Player = Resources.Players.GetPlayer(Device, UserID);

                    if (Device.Player != null)
                    {
                        if (string.Equals(this.Token, this.Device.Player.Token))
                        {
                            Login();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                    throw;
                }
            }
        }

        internal void Login()
        {
            try
            {
                this.Device.Player.Device = Device;

                this.InitLocation();

                new LoginOkMessage(Device).Send();
                new OwnHomeDataMessage(Device).Send();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Failed to login player!" + Ex);

                throw;
            }
        }

        internal void InitLocation()
        {
            IPEndPoint Endpoint = Device.Socket.RemoteEndPoint as IPEndPoint;

            Device.Player.Region
                = new LocationManager(Endpoint).GetRegion;

            Device.Player.City
                = new LocationManager(Endpoint).GetCity;

            Device.Player.Country
                = new LocationManager(Endpoint).GetCountryCode;
        }
    }
}