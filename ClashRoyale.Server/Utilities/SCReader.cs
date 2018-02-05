using System;
using System.IO;
using System.Text;

namespace ClashRoyale.Server.Utilities
{
    internal class SCReader : BinaryReader
    {
        public SCReader(byte[] Buffer) : base(new MemoryStream(Buffer))
        {
        }

        public byte[] ReadBytes()
        {
            var Length = ReadInt32();

            if (Length == -1) return null;

            return ReadBytes(Length);
        }

        public override long ReadInt64()
        {
            var Buffer = ReadBytesWithEndian(8);

            return BitConverter.ToInt64(Buffer, 0);
        }

        public override int ReadInt32()
        {
            var Buffer = ReadBytesWithEndian(4);

            return BitConverter.ToInt32(Buffer, 0);
        }

        public int ReadInt24()
        {
            var Buffer = ReadBytesWithEndian(3, false);

            return (Buffer[0] << 16) | (Buffer[1] << 8) | Buffer[2];
        }

        public override short ReadInt16()
        {
            var Buffer = ReadBytesWithEndian(2);

            return BitConverter.ToInt16(Buffer, 0);
        }

        public override ulong ReadUInt64()
        {
            var Buffer = ReadBytesWithEndian(8);

            return BitConverter.ToUInt64(Buffer, 0);
        }

        public override uint ReadUInt32()
        {
            var Buffer = ReadBytesWithEndian(4);

            return BitConverter.ToUInt32(Buffer, 0);
        }

        public uint ReadUInt24()
        {
            var Buffer = ReadBytesWithEndian(3, false);

            return (uint) ((Buffer[0] << 16) | (Buffer[1] << 8) | Buffer[2]);
        }

        public override ushort ReadUInt16()
        {
            var Buffer = ReadBytesWithEndian(2);

            return BitConverter.ToUInt16(Buffer, 0);
        }

        public override string ReadString()
        {
            var Length = ReadInt32();

            if (Length == -1 || Length < -1 || Length > BaseStream.Length - BaseStream.Position) return null;

            var Buffer = ReadBytesWithEndian(Length, false);

            return Encoding.UTF8.GetString(Buffer);
        }

        internal byte[] ReadFully()
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = Read(buffer, 0, buffer.Length)) > 0) ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }

        internal uint ReadVUInt()
        {
            return (uint) ReadVInt();
        }

        internal int ReadVInt()
        {
            var num1 = ReadByte();
            var num2 = num1 & 128;
            var num3 = num1 & 63;
            if ((num1 & 64) != 0)
            {
                if (num2 != 0)
                {
                    var num4 = ReadByte();
                    var num5 = ((num4 << 6) & 8128) | num3;
                    if ((num4 & 128) != 0)
                    {
                        var num6 = ReadByte();
                        var num7 = num5 | ((num6 << 13) & 1040384);
                        if ((num6 & 128) != 0)
                        {
                            var num8 = ReadByte();
                            var num9 = num7 | ((num8 << 20) & 133169152);
                            if ((num8 & 128) != 0)
                            {
                                var num10 = ReadByte();
                                num3 = (int) (num9 | (num10 << 27) | 2147483648L);
                            }
                            else
                            {
                                num3 = (int) (num9 | 4160749568L);
                            }
                        }
                        else
                        {
                            num3 = (int) (num7 | 4293918720L);
                        }
                    }
                    else
                    {
                        num3 = (int) (num5 | 4294959104L);
                    }
                }
            }
            else if (num2 != 0)
            {
                var num4 = ReadByte();
                num3 |= (num4 << 6) & 8128;
                if ((num4 & 128) != 0)
                {
                    var num5 = ReadByte();
                    num3 |= (num5 << 13) & 1040384;
                    if ((num5 & 128) != 0)
                    {
                        var num6 = ReadByte();
                        num3 |= (num6 << 20) & 133169152;
                        if ((num6 & 128) != 0)
                        {
                            var num7 = ReadByte();
                            num3 |= num7 << 27;
                        }
                    }
                }
            }

            return num3;
        }

        private byte[] ReadBytesWithEndian(int _Count, bool _Endian = true)
        {
            var _Buffer = new byte[_Count];
            BaseStream.Read(_Buffer, 0, _Count);

            if (BitConverter.IsLittleEndian && _Endian) Array.Reverse(_Buffer);

            return _Buffer;
        }
    }
}