namespace org.acplt.oncrpc
{
	/// <summary>
	/// A collection of constants used for ONC/RPC messages to identify the
	/// type of message.
	/// </summary>
	/// <remarks>
	/// A collection of constants used for ONC/RPC messages to identify the
	/// type of message. Currently, ONC/RPC messages can be either calls or
	/// replies. Calls are sent by ONC/RPC clients to servers to call a remote
	/// procedure (for you "ohohpies" that can be translated into the buzzword
	/// "method"). A server then will answer with a corresponding reply message
	/// (but not in the case of batched calls).
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:41 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcMessageType
	{
		/// <summary>Identifies an ONC/RPC call.</summary>
		/// <remarks>
		/// Identifies an ONC/RPC call. By a "call" a client request that a server
		/// carries out a particular remote procedure.
		/// </remarks>
		public const int ONCRPC_CALL = 0;

		/// <summary>Identifies an ONC/RPC reply.</summary>
		/// <remarks>
		/// Identifies an ONC/RPC reply. A server responds with a "reply" after
		/// a client has sent a "call" for a particular remote procedure, sending
		/// back the results of calling that procedure.
		/// </remarks>
		public const int ONCRPC_REPLY = 1;
	}
}
