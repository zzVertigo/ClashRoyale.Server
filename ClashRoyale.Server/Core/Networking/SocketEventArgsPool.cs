using System.Collections.Generic;
using System.Net.Sockets;

namespace ClashRoyale.Server.Networking
{
    internal class SocketAsyncEventArgsPool
    {
        internal readonly int Capacity;

        internal readonly object Gate = new object();
        internal readonly Stack<SocketAsyncEventArgs> Pool;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SocketAsyncEventArgsPool" /> class.
        /// </summary>
        internal SocketAsyncEventArgsPool(int Capacity)
        {
            this.Capacity = Capacity;
            Pool = new Stack<SocketAsyncEventArgs>(Capacity);
        }

        /// <summary>
        ///     Dequeues this instance.
        /// </summary>
        /// <returns>
        ///     <see cref="SocketAsyncEventArgs" />
        /// </returns>
        internal SocketAsyncEventArgs Dequeue()
        {
            lock (Gate)
            {
                if (Pool.Count > 0) return Pool.Pop();

                return null;
            }
        }

        /// <summary>
        ///     Enqueues the specified item.
        /// </summary>
        /// <param name="AsyncEvent">
        ///     The <see cref="SocketAsyncEventArgs" /> instance containing the event data.
        /// </param>
        internal void Enqueue(SocketAsyncEventArgs AsyncEvent)
        {
            AsyncEvent.AcceptSocket = null;
            AsyncEvent.RemoteEndPoint = null;

            lock (Gate)
            {
                // if (this.Pool.Count < this.Capacity)
                {
                    Pool.Push(AsyncEvent);
                }
            }
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        internal void Dispose()
        {
            lock (Gate)
            {
                Pool.Clear();
            }
        }
    }
}