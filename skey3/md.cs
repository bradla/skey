using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// port from the java version
// http://www.cs.umd.edu/~harry/jotp/

namespace skey3
{
    class md
    {
		protected int A;
		protected int B;
		protected int C;
		protected int D;
		protected int[] d;
        int numwords;

		protected md(string s)
        {
			byte[] inStr = Encoding.ASCII.GetBytes(s);
			sbyte[] signed = Array.ConvertAll(inStr, b => unchecked((sbyte)b));
	
			mdinit(signed);
        }

        protected md(sbyte[] @in)
        {
            mdinit(@in);
        }

        void mdinit(sbyte[] @in)
        {
            int newlen;
            int endblklen;
            int pad;
            int i;
            int datalenbits;

            datalenbits = @in.Length * 8;
            endblklen = @in.Length % 64;
            if (endblklen < 56)
            {
                pad = 64 - endblklen;
            }
            else
            {
                pad = 64 - endblklen + 64;
            }
            newlen = @in.Length + pad;
			sbyte[] b = new sbyte[newlen];
            for (i = 0; i < @in.Length; i++)
            {
                b[i] = @in[i];
            }
				
			unchecked
			{
				b[@in.Length] = (sbyte)0x80;                
			}

            for (i = b.Length + 1; i < newlen - 8; i++)
            {
                b[i] = 0;
            }
            for (i = 0; i < 8; i++)
            {
                b[newlen - 8 + i] = (sbyte)(datalenbits & 255);
                datalenbits >>= 8;
            }
            A = 0x67452301; // 1732584193;
            unchecked
            {
                B = (int)(0xefcdab89); // -271733879; 
                C = (int)(0x98badcfe); // -1732584194;
            }
            D = 0x10325476; // 271733878;
            numwords = newlen / 4;
            d = new int[numwords];
            for (i = 0; i < newlen; i += 4)
            {
                d[i / 4] = (b[i] & 255) + ((b[i + 1] & 255) << 8) + ((b[i + 2] & 255) << 16) + ((b[i + 3] & 255) << 24);
            }
        }

        internal virtual int[] getregs()
        {
            int[] regs =
                new int[] { A, B, C, D };
            return regs;
        }

        internal virtual void calc()
        {
            int AA;
            int BB;
            int CC;
            int DD;
            int i;

            for (i = 0; i < numwords / 16; i++)
            {
                AA = A;
                BB = B;
                CC = C;
                DD = D;
                round1(i);
                round2(i);
                round3(i);
				// for MD5
                round4(i);
                A += AA;
                B += BB;
                C += CC;
                D += DD;
            }
        }

        internal virtual void round1(int blk)
        {
            Console.WriteLine("Danger! Danger! Someone called md.round1()!");
        }

        internal virtual void round2(int blk)
        {
            Console.WriteLine("Danger! Danger! Someone called md.round2()!");
        }

        internal virtual void round3(int blk)
        {
            Console.WriteLine("Danger! Danger! Someone called md.round3()!");
        }

        internal virtual void round4(int blk)
        {
            Console.WriteLine("Danger! Danger! Someone called md.round4()!");
        }
			
		internal static int rotintlft(int val, int numbits)
		{
			var second = (int) (((uint) val) >> (32 - numbits));
			return ((val << numbits) | second);
		}
    }
}
