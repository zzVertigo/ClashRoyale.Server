using System;

namespace ClashRoyale.Server.Library
{
    internal class Crypto
    {
        private RC4 Decryptor;
        private RC4 Encryptor;

        public Crypto()
        {
            InitCiphers("fhsd6f86f67rt8fw78fw789we78r9789wer6re" + "nonce");
        }

        public Crypto(string Key, string Nonce)
        {
            InitCiphers(Key + Nonce);
        }

        private void InitCiphers(string Key)
        {
            Encryptor = new RC4(Key);
            Decryptor = new RC4(Key);

            for (var i = 0; i < Key.Length; i++)
            {
                Encryptor.PRGA();
                Decryptor.PRGA();
            }
        }

        internal void Encrypt(ref byte[] Data)
        {
            if (Data != null)
                for (var i = 0; i < Data.Length; i++)
                    Data[i] ^= Encryptor.PRGA();
            else
                Console.WriteLine("Data for encryption was null..");
        }

        internal void Decrypt(ref byte[] Data)
        {
            if (Data != null)
                for (var i = 0; i < Data.Length; i++)
                    Data[i] ^= Decryptor.PRGA();
            else
                Console.WriteLine("Data for decryption was null..");
        }

        private class RC4
        {
            public RC4(byte[] key)
            {
                Key = KSA(key);
            }

            public RC4(string key)
            {
                Key = KSA(StringToByteArray(key));
            }

            public byte[] Key { get; } // "S"

            private byte i { get; set; }
            private byte j { get; set; }

            public byte PRGA()
            {
                /* Pseudo-Random Generation Algorithm
                 *
                 * The returned value should be XORed with
                 * the data to encrypt or decrypt it.
                 */

                var temp = (byte) 0;

                i = (byte) ((i + 1) % 256);
                j = (byte) ((j + Key[i]) % 256);

                // swap S[i] and S[j];
                temp = Key[i];
                Key[i] = Key[j];
                Key[j] = temp;

                return Key[(Key[i] + Key[j]) % 256]; // value to XOR with data
            }

            private static byte[] KSA(byte[] key)
            {
                /* Key-Scheduling Algorithm
                 *
                 * Used to initialize key array.
                 */

                var keyLength = key.Length;
                var S = new byte[256];

                for (var i = 0; i != 256; i++) S[i] = (byte) i;

                var j = (byte) 0;
                var temp = (byte) 0;

                for (var i = 0; i != 256; i++)
                {
                    j = (byte) ((j + S[i] + key[i % keyLength]) % 256); // meth is working

                    // swap S[i] and S[j];
                    temp = S[i];
                    S[i] = S[j];
                    S[j] = temp;
                }

                return S;
            }

            private static byte[] StringToByteArray(string str)
            {
                var bytes = new byte[str.Length];
                for (var i = 0; i < str.Length; i++) bytes[i] = (byte) str[i];
                return bytes;
            }
        }
    }
}