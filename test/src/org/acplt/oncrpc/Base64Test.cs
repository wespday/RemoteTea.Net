namespace tests.org.acplt.oncrpc
{
	public class Base64Test
	{
		public virtual bool bytecmp(byte[] b1, byte[] b2, int len)
		{
			for (int i = 0; i < len; ++i)
			{
				if (b1[i] != b2[i])
				{
					return false;
				}
			}
			return true;
		}

		public virtual void check(string test, byte[] source, int lenSource, int lenEncoded
			)
		{
			byte[] encoded = new byte[((source.Length + 2) / 3 * 4)];
			byte[] decoded = new byte[source.Length];
			System.Console.Out.Write(test + ": ");
			int len = org.acplt.oncrpc.web.Base64.encode(source, 0, lenSource, encoded, 0);
			if (len != lenEncoded)
			{
				System.Console.Out.WriteLine("**failed**. Expected encoded length = " + lenEncoded
					 + ", got length = " + len);
				return;
			}
			len = org.acplt.oncrpc.web.Base64.decode(encoded, 0, len, decoded, 0);
			if (len != lenSource)
			{
				System.Console.Out.WriteLine("**failed**. Decoded length mismatch, expected " + lenSource
					 + ", got " + len);
				return;
			}
			System.Console.Out.WriteLine("passed.");
		}

		public Base64Test()
		{
			byte[] source = Sharpen.Runtime.getBytesForString("The Foxboro jumps over the lazy I/A"
				);
			check("test-1", source, 1, 4);
			check("test-2", source, 2, 4);
			check("test-3", source, 3, 4);
			check("test-4", source, 4, 8);
			check("test-5", source, source.Length, ((source.Length + 2) / 3) * 4);
		}

		public static void Main(string[] args)
		{
			System.Console.Out.WriteLine("Base64Test");
			try
			{
				new tests.org.acplt.oncrpc.Base64Test();
			}
			catch (System.Exception e)
			{
				Sharpen.Runtime.printStackTrace(e, System.Console.Out);
			}
		}
	}
}
