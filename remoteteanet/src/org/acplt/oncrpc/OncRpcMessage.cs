namespace org.acplt.oncrpc
{
	/// <summary>
	/// The <code>OncRpcMessage</code> class is an abstract superclass for all
	/// the message types ONC/RPC defines (well, an overwhelming count of two).
	/// </summary>
	/// <remarks>
	/// The <code>OncRpcMessage</code> class is an abstract superclass for all
	/// the message types ONC/RPC defines (well, an overwhelming count of two).
	/// The only things common to all ONC/RPC messages are a message identifier
	/// and the message type. All other things do not come in until derived
	/// classes are introduced.
	/// </remarks>
	/// <version>$Revision: 1.2 $ $Date: 2003/08/14 07:56:37 $ $State: Exp $ $Locker:  $</version>
	/// <author>Harald Albrecht</author>
	public abstract class OncRpcMessage
	{
		/// <summary>
		/// Constructs  a new <code>OncRpcMessage</code> object with default
		/// values: a given message type and no particular message identifier.
		/// </summary>
		/// <remarks>
		/// Constructs  a new <code>OncRpcMessage</code> object with default
		/// values: a given message type and no particular message identifier.
		/// </remarks>
		public OncRpcMessage(int messageId)
		{
			this.messageId = messageId;
			messageType = -1;
		}

		/// <summary>
		/// The message id is used to identify matching ONC/RPC calls and
		/// replies.
		/// </summary>
		/// <remarks>
		/// The message id is used to identify matching ONC/RPC calls and
		/// replies. This is typically choosen by the communication partner
		/// sending a request. The matching reply then must have the same
		/// message identifier, so the receiver can match calls and replies.
		/// </remarks>
		public int messageId;

		/// <summary>
		/// The kind of ONC/RPC message, which can be either a call or a
		/// reply.
		/// </summary>
		/// <remarks>
		/// The kind of ONC/RPC message, which can be either a call or a
		/// reply. Can be one of the constants defined in
		/// <see cref="OncRpcMessageType">OncRpcMessageType</see>
		/// .
		/// </remarks>
		/// <seealso cref="OncRpcMessageType">OncRpcMessageType</seealso>
		public int messageType;
	}
}
