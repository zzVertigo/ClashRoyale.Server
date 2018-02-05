using System.Collections.Generic;
using System.Linq;
using System.Timers;
using ClashRoyale.Server.Logic;

namespace ClashRoyale.Server.Core
{
    internal class AutoTimers
    {
        internal readonly List<Timer> LTimers;

        internal AutoTimers()
        {
            this.LTimers = new List<Timer>(1);
            {
                this.DeadSockets();
                //this.SavePlayers();
            }

            this.Run();
        }

        internal void SavePlayers()
        {
            Timer Timer = new Timer();

            Timer.Interval = 20000;
            Timer.AutoReset = true;
            Timer.Elapsed += (UCS, Sucks) =>
            {
                Resources.Players.SaveAll();
            };

            this.LTimers.Add(Timer);
        }

        internal void DeadSockets()
        {
            Timer Timer = new Timer();

            Timer.Interval = 30000;
            Timer.AutoReset = true;
            Timer.Elapsed += (UCS, Sucks) =>
            {
                foreach (Player Player in Resources.Players.Values.ToList().FindAll(Player => Player.Device != null && !Player.Device.Connected))
                {
                    Resources.Gateway.Disconnect(Player.Device.Token.Args);
                }
            };

            this.LTimers.Add(Timer);
        }

        internal void Run()
        {
            foreach (Timer Timer in this.LTimers)
            {
                Timer.Start();
            }
        }
    }
}