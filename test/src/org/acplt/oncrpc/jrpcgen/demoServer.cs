using System;
namespace tests.org.acplt.oncrpc.jrpcgen
{
	public class demoServer : demoServerStub
	{
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public demoServer() : base()
		{
		}

		public override void NULL_1()
		{
		}

		// definetely nothing to do here...
		public override void NULL_2()
		{
		}

		// definetely nothing to do here...
		public override string Echo_1(string @params)
		{
			return @params;
		}

		public override bool Checkfoo_1(int @params)
		{
			return @params == ENUMFOO.FOO;
		}

		public override int Foo_1()
		{
			return ENUMFOO.FOO;
		}

		public override string Concat_1(STRINGVECTOR @params
			)
		{
			System.Text.StringBuilder result = new System.Text.StringBuilder();
			int size = @params.value.Length;
			for (int idx = 0; idx < size; ++idx)
			{
				result.Append(@params.value[idx].value);
			}
			return result.ToString();
		}

		public override LINKEDLIST Ll_1(LINKEDLIST
			 @params)
		{
			LINKEDLIST newNode = new LINKEDLIST
				();
			newNode.foo = 42;
			newNode.next = @params;
			return newNode;
		}

		public override SOMERESULT ReadSomeResult_1()
		{
			SOMERESULT res = new SOMERESULT
				();
			return res;
		}

		public override string Cat_2(string arg1, string arg2)
		{
			return arg1 + arg2;
		}

		public override string Cat3_2(string one, string two, string three)
		{
			return one + two + three;
		}

		public override string Checkfoo_2(int foo)
		{
			return "You are foo" + foo + ".";
		}

		public override LINKEDLIST Llcat_2(LINKEDLIST
			 l1, LINKEDLIST l2)
		{
			l2.next = l1;
			return l2;
		}

		public override void Test_2(string a, int b, int c, int d)
		{
		}

        public override double Mult_2(double a, double b)
        {
            return a * b;
        }

		public static void Main(string[] args)
		{
			Console.Out.WriteLine("Starting demoServer...");
			try
			{
				demoServer server = new demoServer
					();
                server.run();
			}
			catch (System.Exception e)
			{
				Console.Out.WriteLine("demoServer oops:");
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
			}
			Console.Out.WriteLine("demoServer stopped.");
		}
	}
}
