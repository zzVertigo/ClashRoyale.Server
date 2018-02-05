namespace ClashRoyale.Server.Core
{
    internal class Settings
    {
        /// <summary>
        ///     The unique server identifier, used to partition the database.
        /// </summary>
        internal const int ServerID = 0;

        /// <summary>
        ///     If set to true, the server will only accept authorized ip's.
        /// </summary>
        internal const bool Local = false;

        /// <summary>
        ///     The length of the buffer used to send packets.
        /// </summary>
        internal const int SendBuffer = 2048 * 1;

        /// <summary>
        ///     The length of the buffer used to receive packets.
        /// </summary>
        internal const int ReceiveBuffer = 2048 * 1;

        /// <summary>
        ///     The maximum of players we can handle at same time.
        /// </summary>
        internal const int MaxPlayers = 1000 * 0;

        /// <summary>
        ///     The maximum of send operation the program can process.
        /// </summary>
        internal const int MaxSends = 1000 * 1;

        /// <summary>
        ///     Whether the server is in maintenance mode or not.
        /// </summary>
        internal const bool Maintenance = false;
    }
}