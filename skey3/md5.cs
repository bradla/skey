using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// port from the java version
// http://www.cs.umd.edu/~harry/jotp/

namespace skey3
{
    class md5 : md
    {
        internal md5(string s)
            : base(s)
        {
        }

        internal md5(sbyte[] @in)
            : base(@in)
        {
        }

        internal static int F(int x, int y, int z)
        {
            return x & y | ~x & z;
        }

        internal static int G(int x, int y, int z)
        {
            return x & z | y & ~z;
        }

        internal static int H(int x, int y, int z)
        {
            return x ^ y ^ z;
        }

        internal static int I(int x, int y, int z)
        {
            return y ^ (x | ~z);
        }

        internal override void round1(int blk)
        {
            unchecked
            {
				A = rotintlft(A + F(B, C, D) + d[0 + 16 * blk] + (int)0xd76aa478, 7) + B;
				D = rotintlft(D + F(A, B, C) + d[1 + 16 * blk] + (int)0xe8c7b756, 12) + A;
				C = rotintlft(C + F(D, A, B) + d[2 + 16 * blk] + 0x242070db, 17) + D;
				B = rotintlft(B + F(C, D, A) + d[3 + 16 * blk] + (int)0xc1bdceee, 22) + C;

				A = rotintlft(A + F(B, C, D) + d[4 + 16 * blk] + (int)0xf57c0faf, 7) + B;
				D = rotintlft(D + F(A, B, C) + d[5 + 16 * blk] + 0x4787c62a, 12) + A;
				C = rotintlft(C + F(D, A, B) + d[6 + 16 * blk] + (int)0xa8304613, 17) + D;
				B = rotintlft(B + F(C, D, A) + d[7 + 16 * blk] + (int)0xfd469501, 22) + C;
				A = rotintlft(A + F(B, C, D) + d[8 + 16 * blk] + 0x698098d8, 7) + B;
				D = rotintlft(D + F(A, B, C) + d[9 + 16 * blk] + (int)0x8b44f7af, 12) + A;
				C = rotintlft(C + F(D, A, B) + d[10 + 16 * blk] + (int)0xffff5bb1, 17) + D;
				B = rotintlft(B + F(C, D, A) + d[11 + 16 * blk] + (int)0x895cd7be, 22) + C;
				A = rotintlft(A + F(B, C, D) + d[12 + 16 * blk] + 0x6b901122, 7) + B;
				D = rotintlft(D + F(A, B, C) + d[13 + 16 * blk] + (int)0xfd987193, 12) + A;
				C = rotintlft(C + F(D, A, B) + d[14 + 16 * blk] + (int)0xa679438e, 17) + D;
				B = rotintlft(B + F(C, D, A) + d[15 + 16 * blk] + 0x49b40821, 22) + C;
            }
        }

		internal override void round2(int blk)
		{
			unchecked
			{
				A = rotintlft(A + G(B, C, D) + d[1 + 16 * blk] + (int)0xf61e2562, 5) + B;
				D = rotintlft(D + G(A, B, C) + d[6 + 16 * blk] + (int)0xc040b340, 9) + A;
				C = rotintlft(C + G(D, A, B) + d[11 + 16 * blk] + 0x265e5a51, 14) + D;
				B = rotintlft(B + G(C, D, A) + d[0 + 16 * blk] + (int)0xe9b6c7aa, 20) + C;
				A = rotintlft(A + G(B, C, D) + d[5 + 16 * blk] + (int)0xd62f105d, 5) + B;
				D = rotintlft(D + G(A, B, C) + d[10 + 16 * blk] + 0x02441453, 9) + A;
				C = rotintlft(C + G(D, A, B) + d[15 + 16 * blk] + (int)0xd8a1e681, 14) + D;
				B = rotintlft(B + G(C, D, A) + d[4 + 16 * blk] + (int)0xe7d3fbc8, 20) + C;
				A = rotintlft(A + G(B, C, D) + d[9 + 16 * blk] + 0x21e1cde6, 5) + B;
				D = rotintlft(D + G(A, B, C) + d[14 + 16 * blk] + (int)0xc33707d6, 9) + A;
				C = rotintlft(C + G(D, A, B) + d[3 + 16 * blk] + (int)0xf4d50d87, 14) + D;
				B = rotintlft(B + G(C, D, A) + d[8 + 16 * blk] + 0x455a14ed, 20) + C;
				A = rotintlft(A + G(B, C, D) + d[13 + 16 * blk] + (int)0xa9e3e905, 5) + B;
				D = rotintlft(D + G(A, B, C) + d[2 + 16 * blk] + (int)0xfcefa3f8, 9) + A;
				C = rotintlft(C + G(D, A, B) + d[7 + 16 * blk] + 0x676f02d9, 14) + D;
				B = rotintlft(B + G(C, D, A) + d[12 + 16 * blk] + (int)0x8d2a4c8a, 20) + C;
			}
		}

		internal override void round3(int blk)
		{
			unchecked
			{
				A = rotintlft(A + H(B, C, D) + d[5 + 16 * blk] + (int)0xfffa3942, 4) + B;
				D = rotintlft(D + H(A, B, C) + d[8 + 16 * blk] + (int)0x8771f681, 11) + A;
				C = rotintlft(C + H(D, A, B) + d[11 + 16 * blk] + 0x6d9d6122, 16) + D;
				B = rotintlft(B + H(C, D, A) + d[14 + 16 * blk] + (int)0xfde5380c, 23) + C;
				A = rotintlft(A + H(B, C, D) + d[1 + 16 * blk] + (int)0xa4beea44, 4) + B;
				D = rotintlft(D + H(A, B, C) + d[4 + 16 * blk] + 0x4bdecfa9, 11) + A;
				C = rotintlft(C + H(D, A, B) + d[7 + 16 * blk] + (int)0xf6bb4b60, 16) + D;
				B = rotintlft(B + H(C, D, A) + d[10 + 16 * blk] + (int)0xbebfbc70, 23) + C;
				A = rotintlft(A + H(B, C, D) + d[13 + 16 * blk] + 0x289b7ec6, 4) + B;
				D = rotintlft(D + H(A, B, C) + d[0 + 16 * blk] + (int)0xeaa127fa, 11) + A;
				C = rotintlft(C + H(D, A, B) + d[3 + 16 * blk] + (int)0xd4ef3085, 16) + D;
				B = rotintlft(B + H(C, D, A) + d[6 + 16 * blk] + 0x04881d05, 23) + C;
				A = rotintlft(A + H(B, C, D) + d[9 + 16 * blk] + (int)0xd9d4d039, 4) + B;
				D = rotintlft(D + H(A, B, C) + d[12 + 16 * blk] + (int)0xe6db99e5, 11) + A;
				C = rotintlft(C + H(D, A, B) + d[15 + 16 * blk] + 0x1fa27cf8, 16) + D;
				B = rotintlft(B + H(C, D, A) + d[2 + 16 * blk] + (int)0xc4ac5665, 23) + C;
			}
		}

		internal override void round4(int blk)
		{
			unchecked
			{
				A = rotintlft(A + I(B, C, D) + d[0 + 16 * blk] + (int)0xf4292244, 6) + B;
				D = rotintlft(D + I(A, B, C) + d[7 + 16 * blk] + 0x432aff97, 10) + A;
				C = rotintlft(C + I(D, A, B) + d[14 + 16 * blk] + (int)0xab9423a7, 15) + D;
				B = rotintlft(B + I(C, D, A) + d[5 + 16 * blk] + (int)0xfc93a039, 21) + C;
				A = rotintlft(A + I(B, C, D) + d[12 + 16 * blk] + 0x655b59c3, 6) + B;
				D = rotintlft(D + I(A, B, C) + d[3 + 16 * blk] + (int)0x8f0ccc92, 10) + A;
				C = rotintlft(C + I(D, A, B) + d[10 + 16 * blk] + (int)0xffeff47d, 15) + D;
				B = rotintlft(B + I(C, D, A) + d[1 + 16 * blk] + (int)0x85845dd1, 21) + C;
				A = rotintlft(A + I(B, C, D) + d[8 + 16 * blk] + 0x6fa87e4f, 6) + B;
				D = rotintlft(D + I(A, B, C) + d[15 + 16 * blk] + (int)0xfe2ce6e0, 10) + A;
				C = rotintlft(C + I(D, A, B) + d[6 + 16 * blk] + (int)0xa3014314, 15) + D;
				B = rotintlft(B + I(C, D, A) + d[13 + 16 * blk] + 0x4e0811a1, 21) + C;
				A = rotintlft(A + I(B, C, D) + d[4 + 16 * blk] + (int)0xf7537e82, 6) + B;
				D = rotintlft(D + I(A, B, C) + d[11 + 16 * blk] + (int)0xbd3af235, 10) + A;
				C = rotintlft(C + I(D, A, B) + d[2 + 16 * blk] + 0x2ad7d2bb, 15) + D;
				B = rotintlft(B + I(C, D, A) + d[9 + 16 * blk] + (int)0xeb86d391, 21) + C;
			}
		}
    } 
}
