using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n64crc
{
    class N64CRC
    {
        private static uint N64_HEADER_SIZE = 0x40;
        private static uint N64_BC_SIZE = 0x1000 - N64_HEADER_SIZE;

        private static uint N64_CRC1 = 0x10;
        private static uint N64_CRC2 = 0x14;

        private static uint CHECKSUM_START = 0x00001000;
        private static uint CHECKSUM_LENGTH = 0x00100000;
        private static uint CHECKSUM_CIC6102 = 0xF8CA4DDC;
        private static uint CHECKSUM_CIC6103 = 0xA3886759;
        private static uint CHECKSUM_CIC6105 = 0xDF26F436;
        private static uint CHECKSUM_CIC6106 = 0x1FEA617A;

        private static uint[] crc_table = new uint[256];

        private static uint ROL(uint i, int b)
        {
            return (uint)(((i) << (b)) | ((i) >> (32 - b)));
        }

        private static uint BYTES2LONG(byte[] b, uint offset)
        {
            return (uint)(b[offset] << 24 | b[offset + 1] << 16 | b[offset + 2] << 8 | b[offset + 3]);
        }

        private static void Write32(ref byte[] Buffer, uint Offset, uint Value)
        {
            Buffer[Offset] = (byte)((Value & 0xFF000000) >> 24);
	        Buffer[Offset + 1] = (byte)((Value & 0x00FF0000) >> 16);
	        Buffer[Offset + 2] = (byte)((Value & 0x0000FF00) >> 8);
	        Buffer[Offset + 3] = (byte)((Value & 0x000000FF));
        }

        private static void gen_table()
        {
            uint crc, poly;

            poly = 0xEDB88320;
            for (uint i = 0; i < 256; i++)
            {
                crc = i;
                for (uint j = 8; j > 0; j--)
                {
                    if ((crc & 1) != 0) crc = (crc >> 1) ^ poly;
                    else crc >>= 1;
                }
                crc_table[i] = crc;
            }
        }

        private static uint crc32(byte[] data, uint offset, uint len)
        {
            uint crc = ~(uint)0;
            int i;

            for (i = 0; i < len; i++)
            {
                crc = (crc >> 8) ^ crc_table[(crc ^ data[i + offset]) & 0xFF];
            }

            return ~crc;
        }

        private static int N64GetCIC(byte[] data)
        {
            switch (crc32(data, N64_HEADER_SIZE, N64_BC_SIZE))
            {
                case 0x6170A4A1: return 6101;
                case 0x90BB6CB5: return 6102;
                case 0x0B050EE0: return 6103;
                case 0x98BC2C86: return 6105;
                case 0xACC8580A: return 6106;
            }

            return 6105;
        }

        private static int N64CalcCRC(ref uint[] crc, byte[] data)
        {
            int bootcode;
            uint seed, i;

            uint t1, t2, t3;
            uint t4, t5, t6;
            uint r, d;
            
            switch ((bootcode = N64GetCIC(data)))
            {
                case 6101:
                case 6102:
                    seed = CHECKSUM_CIC6102;
                    break;
                case 6103:
                    seed = CHECKSUM_CIC6103;
                    break;
                case 6105:
                    seed = CHECKSUM_CIC6105;
                    break;
                case 6106:
                    seed = CHECKSUM_CIC6106;
                    break;
                default:
                    return 1;
            }

            t1 = t2 = t3 = t4 = t5 = t6 = seed;

            i = CHECKSUM_START;
            while (i < (CHECKSUM_START + CHECKSUM_LENGTH))
            {
                d = BYTES2LONG(data, i);
                if ((t6 + d) < t6) t4++;
                t6 += d;
                t3 ^= d;
                r = ROL(d, (int)(d & 0x1F));
                t5 += r;
                if (t2 > d) t2 ^= r;
                else t2 ^= t6 ^ d;

                if (bootcode == 6105) t1 += BYTES2LONG(data, N64_HEADER_SIZE + 0x0710 + (i & 0xFF)) ^ d;
                else t1 += t5 ^ d;

                i += 4;
            }
            if (bootcode == 6103)
            {
                crc[0] = (t6 ^ t4) + t3;
                crc[1] = (t5 ^ t2) + t1;
            }
            else if (bootcode == 6106)
            {
                crc[0] = (t6 * t4) + t3;
                crc[1] = (t5 * t2) + t1;
            }
            else
            {
                crc[0] = t6 ^ t4 ^ t3;
                crc[1] = t5 ^ t2 ^ t1;
            }

            return 0;
        }

        public static void CalculateROMChecksums(ref byte[] rom)
        {
            uint[] crc = new uint[2];

            //Init CRC algorithm
            gen_table();

            if (N64CalcCRC(ref crc, rom) == 1)
            {
                throw new Exception("Unable to calculate CRC");
            }
            else
            {
                Write32(ref rom, N64_CRC1, crc[0]);
                Write32(ref rom, N64_CRC2, crc[1]);
            }
        }
    }
}
