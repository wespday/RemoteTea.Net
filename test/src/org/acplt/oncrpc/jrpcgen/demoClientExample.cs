using System.Net;
using org.acplt.oncrpc;
using System;

namespace tests.org.acplt.oncrpc.jrpcgen
{
	public class demoClientExample
	{
		public static void Main(string[] args)
		{
			demoClient client = null;
			try
			{
				client = new demoClient(IPAddress.Loopback,
					OncRpcProtocols.ONCRPC_TCP);
			}
			catch (System.Exception e)
			{
				Console.Out.WriteLine("demoClientExample: oops when creating RPC client:");
                Console.Out.WriteLine(e.StackTrace);
			}
			client.GetClient().setTimeout(300 * 1000);
			Console.Out.Write("About to ping: ");
			try
			{
				client.NULL_1();
				System.Console.Out.WriteLine("ok");
			}
			catch (System.Exception e)
			{
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
                return;
			}
			Console.Out.Write("About to echo: ");
			try
			{
				string text = "Hello, Remote Tea!";
				string echo = client.echo_1(text);
				if (!echo.Equals(text))
				{
					System.Console.Out.WriteLine(" oops. Got \"" + echo + "\" instead of \"" + text +
						 "\"");
				}
				System.Console.Out.WriteLine("ok. Echo: \"" + echo + "\"");
			}
			catch (System.Exception e)
			{
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
                return;
			}
			System.Console.Out.Write("About to concatenating: ");
			try
			{
				STRINGVECTOR strings = new STRINGVECTOR
					();
				strings.value = new STRING[3];
				strings.value[0] = new STRING("Hello, ");
				strings.value[1] = new STRING("Remote ");
				strings.value[2] = new STRING("Tea!");
				string echo = client.concat_1(strings);
				System.Console.Out.WriteLine("ok. Echo: \"" + echo + "\"");
			}
			catch (System.Exception e)
			{
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
                return;
			}
			System.Console.Out.Write("About to concatenating exactly three strings: ");
			try
			{
				string echo = client.cat3_2("(arg1:Hello )", "(arg2:Remote )", "(arg3:Tea!)");
				System.Console.Out.WriteLine("ok. Echo: \"" + echo + "\"");
			}
			catch (System.Exception e)
			{
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
                return;
			}
			System.Console.Out.Write("About to check for foo: ");
			try
			{
				if (client.checkfoo_1(ENUMFOO.BAR))
				{
					System.Console.Out.WriteLine("oops: but a bar is not a foo!");
					return;
				}
				System.Console.Out.Write("not bar: ");
				if (!client.checkfoo_1(ENUMFOO.FOO))
				{
					System.Console.Out.WriteLine("oops: a foo should be a foo!");
					return;
				}
				System.Console.Out.WriteLine("but a foo. ok.");
			}
			catch (System.Exception e)
			{
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
                return;
			}
			System.Console.Out.Write("About to get a foo: ");
			try
			{
				if (client.foo_1() != ENUMFOO.FOO)
				{
					System.Console.Out.WriteLine("oops: got a bar instead of a foo!");
					return;
				}
				System.Console.Out.WriteLine("ok.");
			}
			catch (System.Exception e)
			{
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
                return;
			}
            System.Console.Out.Write("About to get a numbered foo string: ");
            try
            {
                string echo = client.checkfoo_2(42);
                System.Console.Out.WriteLine("ok. Echo: \"" + echo + "\"");
            }
            catch (System.Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
                return;
            }
            System.Console.Out.Write("About to test doubles: ");
            try
            {
                double result = client.mult_2(5.0, 7.312);
                if (result == (5.0 * 7.312))
                {
                    System.Console.Out.WriteLine("ok. Result: \"" + result + "\"");
                }
                else
                {
                    System.Console.Out.WriteLine("fail. Result \"" + result + "\"");
                }
            }
            catch (System.Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
                return;
            }
            System.Console.Out.Write("Linked List test: ");
			try
			{
				LINKEDLIST node1 = new LINKEDLIST
					();
				node1.foo = 0;
				LINKEDLIST node2 = new LINKEDLIST
					();
				node2.foo = 8;
				node1.next = node2;
				LINKEDLIST node3 = new LINKEDLIST
					();
				node3.foo = 15;
				node2.next = node3;
				LINKEDLIST list = client.ll_1(node1);
				System.Console.Out.Write("ok. Echo: ");
				while (list != null)
				{
					System.Console.Out.Write(list.foo + ", ");
					list = list.next;
				}
				System.Console.Out.WriteLine();
			}
			catch (System.Exception e)
			{
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
                return;
			}
			System.Console.Out.Write("Linking Linked Lists test: ");
			try
			{
				LINKEDLIST node1 = new LINKEDLIST
					();
				node1.foo = 0;
				LINKEDLIST node2 = new LINKEDLIST
					();
				node2.foo = 8;
				LINKEDLIST node3 = new LINKEDLIST
					();
				node3.foo = 15;
				node2.next = node3;
				LINKEDLIST list = client.llcat_2(node2, node1);
				System.Console.Out.Write("ok. Echo: ");
				while (list != null)
				{
					System.Console.Out.Write(list.foo + ", ");
					list = list.next;
				}
				System.Console.Out.WriteLine();
			}
			catch (System.Exception e)
			{
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
                return;
			}
			try
			{
				client.close();
			}
			catch (System.Exception e)
			{
				Console.Out.WriteLine("demoClientExample: oops when closing client:");
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
            }
			client = null;
			System.Console.Out.WriteLine("All tests passed.");
		}
	}
}
