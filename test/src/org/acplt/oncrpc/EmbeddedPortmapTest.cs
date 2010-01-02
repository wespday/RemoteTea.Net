using System;
using org.acplt.oncrpc;
using System.Net;
using org.acplt.oncrpc.apps.jportmap;
using System.Threading;
namespace tests.org.acplt.oncrpc
{
	public class EmbeddedPortmapTest
	{
		public OncRpcEmbeddedPortmap epm;

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		/// <exception cref="java.net.UnknownHostException"></exception>
		public EmbeddedPortmapTest()
		{
			//
			// Diagnostic: Is a portmapper already running?
			//
			Console.Out.Write("Checking for portmap service: ");
			bool externalPortmap = OncRpcEmbeddedPortmap.isPortmapRunning
				();
			if (externalPortmap)
			{
				Console.Out.WriteLine("A portmap service is already running.");
			}
			else
			{
				Console.Out.WriteLine("No portmap service available.");
			}
			//
			// Create embedded portmap service and check whether is has sprung
			// into action.
			//
			Console.Out.Write("Creating embedded portmap instance: ");
			try
			{
				epm = new OncRpcEmbeddedPortmap();
			}
			catch (System.IO.IOException e)
			{
				Console.Out.WriteLine("ERROR: failed:");
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
            }
			catch (OncRpcException e)
			{
				Console.Out.WriteLine("ERROR: failed:");
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
            }
			if (!epm.embeddedPortmapInUse())
			{
				Console.Out.Write("embedded service not used: ");
			}
			else
			{
				Console.Out.Write("embedded service started: ");
			}
			if (epm.embeddedPortmapInUse() == externalPortmap)
			{
				Console.Out.WriteLine("ERROR: no service available or both.");
				return;
			}
			Console.Out.WriteLine("Passed.");
			//
			// Now register dummy ONC/RPC program. Note that the embedded
			// portmap service must not automatically spin down when deregistering
			// the non-existing dummy program.
			//
			OncRpcPortmapClient pmap = new OncRpcPortmapClient
				(IPAddress.Loopback);
			Console.Out.Write("Deregistering non-existing program: ");
			pmap.unsetPort(12345678, 42);
			Console.Out.WriteLine("Passed.");
			Console.Out.Write("Registering dummy program: ");
			pmap.setPort(12345678, 42, OncRpcProtocols.ONCRPC_TCP, 42);
			Console.Out.WriteLine("Passed.");
			Console.Out.WriteLine("Press any key to continue...");
            string s = Console.In.ReadLine();
            Console.Out.Write("Deregistering dummy program: ");
			pmap.unsetPort(12345678, 42);
			Console.Out.WriteLine("Passed.");
            // This to match the sleep in the embedded portmap to make sure we return
            // our message to the client before shutting down the socket.  This should
            // be fixed to work with synchronization rather than time, but it's what I
            // got done for the time being.
            Thread.Sleep(1000);
			Console.Out.WriteLine("Press any key to continue...");
            s = Console.In.ReadLine();
            //
			// Check that an embedded portmap service spins down properly if it
			// was started within this test.
			//
			if (OncRpcEmbeddedPortmap.isPortmapRunning() && !externalPortmap)
			{
				Console.Out.WriteLine("ERROR: embedded portmap service still running.");
			}
		}

		public static void Main(string[] args)
		{
			Console.Out.WriteLine("EmbeddedPortmapTest");
			try
			{
				new EmbeddedPortmapTest();
			}
			catch (System.Exception e)
			{
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
            }
			Console.Out.WriteLine("Test finished.");
			Console.Out.WriteLine("Press any key to continue...");
			try
			{
                string s = Console.In.ReadLine();
            }
			catch (System.IO.IOException)
			{
			}
		}
	}
}
