namespace org.acplt.oncrpc
{
	/// <summary>
	/// An abstract adapter class for
	/// <see cref="OncRpcBroadcastListener">receiving</see>
	/// <see cref="OncRpcBroadcastEvent">ONC/RPC broadcast reply events</see>
	/// .
	/// The methods in this class are empty. This class exists as
	/// convenience for creating listener objects.
	/// </summary>
	/// <seealso cref="OncRpcUdpClient">OncRpcUdpClient</seealso>
	/// <seealso cref="OncRpcBroadcastAdapter">OncRpcBroadcastAdapter</seealso>
	/// <seealso cref="OncRpcBroadcastListener">OncRpcBroadcastListener</seealso>
	/// <seealso cref="OncRpcBroadcastEvent">OncRpcBroadcastEvent</seealso>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:40 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public abstract class OncRpcBroadcastAdapter : org.acplt.oncrpc.OncRpcBroadcastListener
	{
		/// <summary>Invoked when a reply to an ONC/RPC broadcast call is received.</summary>
		/// <remarks>Invoked when a reply to an ONC/RPC broadcast call is received.</remarks>
		/// <seealso cref="OncRpcBroadcastEvent">OncRpcBroadcastEvent</seealso>
		public virtual void replyReceived(org.acplt.oncrpc.OncRpcBroadcastEvent evt)
		{
		}
	}
}
