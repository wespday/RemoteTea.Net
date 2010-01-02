namespace org.acplt.oncrpc
{
	/// <summary>
	/// The listener class for
	/// <see cref="OncRpcBroadcastListener">receiving</see>
	/// <see cref="OncRpcBroadcastEvent">ONC/RPC broadcast reply events</see>
	/// .
	/// </summary>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:40 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public interface OncRpcBroadcastListener
	{
		/// <summary>Invoked when a reply to an ONC/RPC broadcast call is received.</summary>
		/// <remarks>
		/// Invoked when a reply to an ONC/RPC broadcast call is received.
		/// <p>Please note that you should not spend too much time when handling
		/// broadcast events, otherwise you'll probably miss some of the incomming
		/// replies. Because most operating systems will not buffer large amount
		/// of incomming UDP/IP datagramms for a given socket, you will experience
		/// packet drops when you stay too long in the processing stage.
		/// </remarks>
		/// <seealso cref="OncRpcBroadcastEvent">OncRpcBroadcastEvent</seealso>
		void replyReceived(org.acplt.oncrpc.OncRpcBroadcastEvent evt);
	}
}
