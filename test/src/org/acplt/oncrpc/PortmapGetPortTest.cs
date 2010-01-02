namespace tests.org.acplt.oncrpc
{
	public class PortmapGetPortTest
	{
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public PortmapGetPortTest()
		{
			//
			// Create a portmap client object, which can then be used to contact
			// a local or remote ONC/RPC portmap process. In this test we contact
			// the local portmapper.
			//
			org.acplt.oncrpc.OncRpcPortmapClient portmap = new org.acplt.oncrpc.OncRpcPortmapClient
				(java.net.InetAddress.getByName("localhost"));
			//portmap.setRetransmissionMode(OncRpcUdpRetransmissionMode.FIXED);
			//portmap.setRetransmissionTimeout(3*1000);
			//
			// Ping the portmapper...
			//
			System.Console.Out.Write("pinging portmapper: ");
			try
			{
				portmap.ping();
			}
			catch (org.acplt.oncrpc.OncRpcException e)
			{
				System.Console.Out.WriteLine("method call failed unexpectedly:");
				Sharpen.Runtime.printStackTrace(e, System.Console.Out);
				System.Environment.Exit(1);
			}
			System.Console.Out.WriteLine("portmapper is alive.");
			//
			// Ask for a non-existent ONC/RPC server.
			//
			int port;
			System.Console.Out.Write("getPort() for non-existing program: ");
			try
			{
				port = portmap.getPort(1, 1, org.acplt.oncrpc.OncRpcProtocols.ONCRPC_UDP);
				System.Console.Out.WriteLine("method call failed (program found).");
			}
			catch (org.acplt.oncrpc.OncRpcException e)
			{
				if (e.getReason() != org.acplt.oncrpc.OncRpcException.RPC_PROGNOTREGISTERED)
				{
					System.Console.Out.WriteLine("method call failed unexpectedly:");
					Sharpen.Runtime.printStackTrace(e, System.Console.Out);
					System.Environment.Exit(10);
				}
				System.Console.Out.WriteLine("succeeded (RPC_PROGNOTREGISTERED).");
			}
			//
			// Register dummy ONC/RPC server.
			//
			System.Console.Out.Write("setPort() dummy server identification: ");
			try
			{
				portmap.setPort(1, 42, org.acplt.oncrpc.OncRpcProtocols.ONCRPC_UDP, 65535);
			}
			catch (org.acplt.oncrpc.OncRpcException e)
			{
				System.Console.Out.WriteLine("method call failed unexpectedly:");
				Sharpen.Runtime.printStackTrace(e, System.Console.Out);
				System.Environment.Exit(12);
			}
			System.Console.Out.WriteLine("succeeded.");
			//
			// Now dump the current list of registered servers.
			//
			org.acplt.oncrpc.OncRpcServerIdent[] list = null;
			int i;
			bool found = false;
			System.Console.Out.Write("listServers(): ");
			try
			{
				list = portmap.listServers();
			}
			catch (org.acplt.oncrpc.OncRpcException e)
			{
				System.Console.Out.WriteLine("method call failed unexpectedly:");
				Sharpen.Runtime.printStackTrace(e, System.Console.Out);
				System.Environment.Exit(20);
			}
			System.Console.Out.WriteLine("succeeded.");
			for (i = 0; i < list.Length; ++i)
			{
				if ((list[i].program == 1) && (list[i].version == 42) && (list[i].protocol == org.acplt.oncrpc.OncRpcProtocols
					.ONCRPC_UDP) && (list[i].port == 65535))
				{
					found = true;
				}
				System.Console.Out.WriteLine("  " + list[i].program + " " + list[i].version + " "
					 + list[i].protocol + " " + list[i].port);
			}
			if (!found)
			{
				System.Console.Out.WriteLine("registered dummy server ident not found.");
				System.Environment.Exit(22);
			}
			//
			// Deregister dummy ONC/RPC server.
			//
			System.Console.Out.Write("unsetPort() dummy server identification: ");
			try
			{
				portmap.unsetPort(1, 42);
			}
			catch (org.acplt.oncrpc.OncRpcException e)
			{
				System.Console.Out.WriteLine("method call failed unexpectedly:");
				Sharpen.Runtime.printStackTrace(e, System.Console.Out);
				System.Environment.Exit(12);
			}
			System.Console.Out.WriteLine("succeeded.");
			//
			// Now dump again the current list of registered servers.
			//
			found = false;
			list = null;
			System.Console.Out.Write("listServers(): ");
			try
			{
				list = portmap.listServers();
			}
			catch (org.acplt.oncrpc.OncRpcException e)
			{
				System.Console.Out.WriteLine("method call failed unexpectedly:");
				Sharpen.Runtime.printStackTrace(e, System.Console.Out);
				System.Environment.Exit(20);
			}
			System.Console.Out.WriteLine("succeeded.");
			for (i = 0; i < list.Length; ++i)
			{
				if ((list[i].program == 1) && (list[i].version == 42) && (list[i].protocol == org.acplt.oncrpc.OncRpcProtocols
					.ONCRPC_UDP) && (list[i].port == 65535))
				{
					found = true;
					break;
				}
			}
			if (found)
			{
				System.Console.Out.WriteLine("registered dummy server ident still found after deregistering."
					);
				System.Environment.Exit(22);
			}
			//
			// Release resources bound by portmap client object as soon as possible
			// so might help the garbage wo/man. Yeah, this is now a political
			// correct comment.
			//
			portmap.close();
			portmap = null;
		}

		public static void Main(string[] args)
		{
			System.Console.Out.WriteLine("PortmapGetPortTest");
			try
			{
				new tests.org.acplt.oncrpc.PortmapGetPortTest();
			}
			catch (System.Exception e)
			{
				Sharpen.Runtime.printStackTrace(e, System.Console.Out);
			}
		}
	}
}
