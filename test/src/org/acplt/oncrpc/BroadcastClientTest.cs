namespace tests.org.acplt.oncrpc
{
	public class BroadcastClientTest : org.acplt.oncrpc.OncRpcBroadcastListener
	{
		internal System.Collections.ArrayList portmappers = new System.Collections.ArrayList
			();

		//
		// List of addresses of portmappers that replied to our call...
		//
		//
		// Remember addresses of replies for later processing. Please note
		// that you should not do any lengthy things (like DNS name lookups)
		// in this event handler, as you will otherwise miss some incomming
		// replies because the OS will drop them.
		//
		public virtual void replyReceived(org.acplt.oncrpc.OncRpcBroadcastEvent evt)
		{
			portmappers.add(evt.getReplyAddress());
			System.Console.Out.Write(".");
		}

		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		/// <exception cref="System.IO.IOException"></exception>
		public BroadcastClientTest()
		{
			//
			// Create a portmap client object, which can then be used to contact
			// the local ONC/RPC ServerTest test server.
			//
			org.acplt.oncrpc.OncRpcUdpClient client = new org.acplt.oncrpc.OncRpcUdpClient(java.net.InetAddress
				.getByName("255.255.255.255"), 100000, 2, 111);
			//
			// Ping all portmappers in this subnet...
			//
			System.Console.Out.Write("pinging portmappers in subnet: ");
			client.setTimeout(5 * 1000);
			try
			{
				client.broadcastCall(0, org.acplt.oncrpc.XdrVoid.XDR_VOID, org.acplt.oncrpc.XdrVoid
					.XDR_VOID, this);
			}
			catch (org.acplt.oncrpc.OncRpcException e)
			{
				System.Console.Out.WriteLine("method call failed unexpectedly:");
				Sharpen.Runtime.printStackTrace(e, System.Console.Out);
				System.Environment.Exit(1);
			}
			System.Console.Out.WriteLine("done.");
			//
			// Print addresses of all portmappers found...
			//
			for (int idx = 0; idx < portmappers.Count; ++idx)
			{
				System.Console.Out.WriteLine("Found: " + ((java.net.InetAddress)portmappers[idx])
					.getHostName() + " (" + ((java.net.InetAddress)portmappers[idx]).getHostAddress(
					) + ")");
			}
			//
			// Release resources bound by portmap client object as soon as possible
			// so might help the garbage wo/man. Yeah, this is now a political
			// correct comment.
			//
			client.close();
			client = null;
		}

		public static void Main(string[] args)
		{
			System.Console.Out.WriteLine("BroadcastClientTest");
			try
			{
				new tests.org.acplt.oncrpc.BroadcastClientTest();
			}
			catch (System.Exception e)
			{
				Sharpen.Runtime.printStackTrace(e, System.Console.Out);
			}
		}
	}
}
