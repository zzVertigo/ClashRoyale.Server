using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClashRoyale.Server.Files.Helpers;

namespace ClashRoyale.Server.Utilities
{
    internal static class SCWriter
    {
        internal static void AddByte(this List<byte> Data, int Value)
        {
            Data.Add((byte) Value);
        }

        internal static void AddInt64(this List<byte> Data, long Value)
        {
            Data.AddRange(BitConverter.GetBytes(Value).Reverse());
        }

        internal static void AddUInt64(this List<byte> Data, ulong Value)
        {
            Data.AddRange(BitConverter.GetBytes(Value).Reverse());
        }

        internal static void AddInt32(this List<byte> Data, int Value)
        {
            Data.AddRange(BitConverter.GetBytes(Value).Reverse());
        }

        internal static void AddUInt32(this List<byte> Data, uint Value)
        {
            Data.AddRange(BitConverter.GetBytes(Value).Reverse());
        }

        internal static void AddInt24(this List<byte> Data, int Value)
        {
            Data.AddRange(BitConverter.GetBytes(Value).Reverse().Skip(1));
        }

        internal static void AddUInt24(this List<byte> Data, uint Value)
        {
            Data.AddRange(BitConverter.GetBytes(Value).Reverse().Skip(1));
        }

        internal static void AddInt16(this List<byte> Data, short Value)
        {
            Data.AddRange(BitConverter.GetBytes(Value).Reverse());
        }

        internal static void AddUInt16(this List<byte> Data, ushort Value)
        {
            Data.AddRange(BitConverter.GetBytes(Value).Reverse());
        }

        internal static void AddBoolean(this List<byte> Data, bool Value)
        {
            Data.Add(Value ? (byte) 1 : (byte) 0);
        }

        internal static void AddString(this List<byte> Data, string Value)
        {
            if (Value != null)
            {
                var Buffer = Encoding.UTF8.GetBytes(Value);

                Data.AddInt32(Buffer.Length);
                Data.AddRange(Buffer);
            }
            else
            {
                Data.AddRange(BitConverter.GetBytes(-1).Reverse());
            }
        }

        internal static byte[] AddHexa(this string Value)
        {
            var Temp = Value.Contains("-") ? Value.Replace("-", string.Empty) : Value.Replace(" ", string.Empty);

            return Enumerable.Range(0, Temp.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(Temp.Substring(x, 2), 16))
                .ToArray();
        }

        internal static void AddData(this List<byte> _Writer, Data _Data)
        {
            var Reference = _Data.ID;
            var RowIndex = _Data.GetID();

            _Writer.AddVInt(Reference);
            _Writer.AddVInt(RowIndex);
        }

        internal static void AddData(this List<byte> _Writer, int _Data)
        {
            _Writer.AddVInt(GlobalID.GetType(_Data));
            _Writer.AddVInt(GlobalID.GetID(_Data));
        }

        internal static void AddData(this List<byte> _Writer, int _Type, int _ID)
        {
            _Writer.AddVInt(_Type);
            _Writer.AddVInt(_ID);
        }

        internal static void AddVInt(this List<byte> Data, int Value)
        {
            if (Value > 63)
            {
                Data.Add((byte) ((Value & 0x3F) | 0x80));

                if (Value > 8191)
                {
                    Data.Add((byte) ((Value >> 6) | 0x80));

                    if (Value > 1048575)
                    {
                        Data.Add((byte) ((Value >> 13) | 0x80));

                        if (Value > 134217727)
                        {
                            Data.Add((byte) ((Value >> 20) | 0x80));
                            Value >>= 27 & 0x7F;
                        }
                        else
                        {
                            Value >>= 20 & 0x7F;
                        }
                    }
                    else
                    {
                        Value >>= 13 & 0x7F;
                    }
                }
                else
                {
                    Value >>= 6 & 0x7F;
                }
            }

            Data.Add((byte) Value);
        }

        internal static void AddVInt(this List<byte> Data, int Value, int Prefix)
        {
            Data.AddVInt(Prefix);
            Data.AddVInt(Value);
        }

        internal static void AddHexa(this List<byte> _Packet, string _Value)
        {
            _Packet.AddRange(_Value.HexaToBytes());
        }

        internal static byte[] HexaToBytes(this string _Value)
        {
            var _Tmp = _Value.Replace("-", string.Empty).Replace(" ", string.Empty);
            return Enumerable.Range(0, _Tmp.Length).Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(_Tmp.Substring(x, 2), 16)).ToArray();
        }
    }
}