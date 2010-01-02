namespace org.acplt.oncrpc
{
	/// <summary>
	/// The <code>OncRpcCallMessage</code> class represents a remote procedure call
	/// message as defined by ONC/RPC in RFC 1831.
	/// </summary>
	/// <remarks>
	/// The <code>OncRpcCallMessage</code> class represents a remote procedure call
	/// message as defined by ONC/RPC in RFC 1831. Such messages are sent by ONC/RPC
	/// clients to servers in order to request a remote procedure call.
	/// <p>Note that this is an abstract class. Because call message objects also
	/// need to deal with authentication protocol issues, they need help of so-called
	/// authentication protocol handling objects. These objects are of different
	/// classes, depending on where they are used (either within the server or
	/// the client).
	/// <p>Please also note that this class implements no encoding or decoding
	/// functionality: it doesn't need them. Only derived classes will be able
	/// to be encoded on the side of the client and decoded at the end of the
	/// server.
	/// </remarks>
	/// <version>$Revision: 1.2 $ $Date: 2003/08/14 07:55:07 $ $State: Exp $ $Locker:  $</version>
	/// <author>Harald Albrecht</author>
	public abstract class OncRpcCallMessage : org.acplt.oncrpc.OncRpcMessage
	{
		/// <summary>Protocol version used by this ONC/RPC Java implementation.</summary>
		/// <remarks>
		/// Protocol version used by this ONC/RPC Java implementation. The protocol
		/// version 2 is defined in RFC 1831.
		/// </remarks>
		public const int ONCRPC_VERSION = 2;

		/// <summary>Protocol version used by this ONC/RPC call message.</summary>
		/// <remarks>Protocol version used by this ONC/RPC call message.</remarks>
		public int oncRpcVersion;

		/// <summary>Program number of this particular remote procedure call message.</summary>
		/// <remarks>Program number of this particular remote procedure call message.</remarks>
		public int program;

		/// <summary>Program version number of this particular remote procedure call message.
		/// 	</summary>
		/// <remarks>Program version number of this particular remote procedure call message.
		/// 	</remarks>
		public int version;

		/// <summary>Number (identifier) of remote procedure to call.</summary>
		/// <remarks>Number (identifier) of remote procedure to call.</remarks>
		public int procedure;

		/// <summary>Constructs and initialises a new ONC/RPC call message header.</summary>
		/// <remarks>Constructs and initialises a new ONC/RPC call message header.</remarks>
		/// <param name="messageId">
		/// An identifier choosen by an ONC/RPC client to uniquely
		/// identify matching call and reply messages.
		/// </param>
		/// <param name="program">Program number of the remote procedure to call.</param>
		/// <param name="version">Program version number of the remote procedure to call.</param>
		/// <param name="procedure">Procedure number (identifier) of the procedure to call.</param>
		public OncRpcCallMessage(int messageId, int program, int version, int procedure) : 
			base(messageId)
		{
			messageType = org.acplt.oncrpc.OncRpcMessageType.ONCRPC_CALL;
			oncRpcVersion = ONCRPC_VERSION;
			this.program = program;
			this.version = version;
			this.procedure = procedure;
		}

		/// <summary>Constructs a new (incompletely initialized) ONC/RPC call message header.
		/// 	</summary>
		/// <remarks>
		/// Constructs a new (incompletely initialized) ONC/RPC call message header.
		/// The <code>messageType</code> is set to
		/// <see cref="OncRpcMessageType.ONCRPC_CALL">OncRpcMessageType.ONCRPC_CALL</see>
		/// and the <code>oncRpcVersion</code>
		/// is set to
		/// <see cref="ONCRPC_VERSION">ONCRPC_VERSION</see>
		/// .
		/// </remarks>
		public OncRpcCallMessage() : base(0)
		{
			messageType = org.acplt.oncrpc.OncRpcMessageType.ONCRPC_CALL;
			oncRpcVersion = ONCRPC_VERSION;
			this.program = 0;
			this.version = 0;
			this.procedure = 0;
		}
	}
}
