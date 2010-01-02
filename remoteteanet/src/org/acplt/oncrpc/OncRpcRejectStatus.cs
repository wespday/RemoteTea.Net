namespace org.acplt.oncrpc
{
	/// <summary>
	/// A collection of constants used to describe why a remote procedure call
	/// message was rejected.
	/// </summary>
	/// <remarks>
	/// A collection of constants used to describe why a remote procedure call
	/// message was rejected. This constants are used in
	/// <see cref="OncRpcReplyMessage">OncRpcReplyMessage</see>
	/// objects, which represent rejected messages if their
	/// <see cref="OncRpcReplyMessage.replyStatus">OncRpcReplyMessage.replyStatus</see>
	/// field has the value
	/// <see cref="OncRpcReplyStatus.ONCRPC_MSG_DENIED">OncRpcReplyStatus.ONCRPC_MSG_DENIED
	/// 	</see>
	/// .
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:41 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcRejectStatus
	{
		/// <summary>Wrong ONC/RPC protocol version used in call (it needs to be version 2).</summary>
		/// <remarks>Wrong ONC/RPC protocol version used in call (it needs to be version 2).</remarks>
		public const int ONCRPC_RPC_MISMATCH = 0;

		/// <summary>The remote ONC/RPC server could not authenticate the caller.</summary>
		/// <remarks>The remote ONC/RPC server could not authenticate the caller.</remarks>
		public const int ONCRPC_AUTH_ERROR = 1;
	}
}
