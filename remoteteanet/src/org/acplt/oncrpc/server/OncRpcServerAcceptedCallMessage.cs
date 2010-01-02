namespace org.acplt.oncrpc.server
{
	/// <summary>
	/// The <code>OncRpcServerAcceptedCallMessage</code> class represents (on the
	/// sender's side) an accepted ONC/RPC call.
	/// </summary>
	/// <remarks>
	/// The <code>OncRpcServerAcceptedCallMessage</code> class represents (on the
	/// sender's side) an accepted ONC/RPC call. In ONC/RPC babble, an "accepted"
	/// call does not mean that it carries a result from the remote procedure
	/// call, but rather that the call was accepted at the basic ONC/RPC level
	/// and no authentification failure or else occured.
	/// <p>This ONC/RPC reply header class is only a convenience for server
	/// implementors.
	/// </remarks>
	/// <version>$Revision: 1.2 $ $Date: 2003/08/14 08:10:59 $ $State: Exp $ $Locker:  $</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcServerAcceptedCallMessage : org.acplt.oncrpc.server.OncRpcServerReplyMessage
	{
		/// <summary>
		/// Constructs an <code>OncRpcServerAcceptedCallMessage</code> object which
		/// represents an accepted call, which was also successfully executed,
		/// so the reply will contain information from the remote procedure call.
		/// </summary>
		/// <remarks>
		/// Constructs an <code>OncRpcServerAcceptedCallMessage</code> object which
		/// represents an accepted call, which was also successfully executed,
		/// so the reply will contain information from the remote procedure call.
		/// </remarks>
		/// <param name="call">
		/// The call message header, which is used to construct the
		/// matching reply message header from.
		/// </param>
		public OncRpcServerAcceptedCallMessage(org.acplt.oncrpc.server.OncRpcServerCallMessage
			 call) : base(call, org.acplt.oncrpc.OncRpcReplyStatus.ONCRPC_MSG_ACCEPTED, org.acplt.oncrpc.OncRpcAcceptStatus
			.ONCRPC_SUCCESS, org.acplt.oncrpc.OncRpcReplyMessage.UNUSED_PARAMETER, org.acplt.oncrpc.OncRpcReplyMessage
			.UNUSED_PARAMETER, org.acplt.oncrpc.OncRpcReplyMessage.UNUSED_PARAMETER, org.acplt.oncrpc.OncRpcAuthStatus
			.ONCRPC_AUTH_OK)
		{
		}

		/// <summary>
		/// Constructs an <code>OncRpcAcceptedCallMessage</code> object which
		/// represents an accepted call, which was not necessarily successfully
		/// carried out.
		/// </summary>
		/// <remarks>
		/// Constructs an <code>OncRpcAcceptedCallMessage</code> object which
		/// represents an accepted call, which was not necessarily successfully
		/// carried out. The parameter <code>acceptStatus</code> will then
		/// indicate the exact outcome of the ONC/RPC call.
		/// </remarks>
		/// <param name="call">
		/// The call message header, which is used to construct the
		/// matching reply message header from.
		/// </param>
		/// <param name="acceptStatus">
		/// The accept status of the call. This can be any
		/// one of the constants defined in the
		/// <see cref="org.acplt.oncrpc.OncRpcAcceptStatus">org.acplt.oncrpc.OncRpcAcceptStatus
		/// 	</see>
		/// interface.
		/// </param>
		public OncRpcServerAcceptedCallMessage(org.acplt.oncrpc.server.OncRpcServerCallMessage
			 call, int acceptStatus) : base(call, org.acplt.oncrpc.OncRpcReplyStatus.ONCRPC_MSG_ACCEPTED
			, acceptStatus, org.acplt.oncrpc.OncRpcReplyMessage.UNUSED_PARAMETER, org.acplt.oncrpc.OncRpcReplyMessage
			.UNUSED_PARAMETER, org.acplt.oncrpc.OncRpcReplyMessage.UNUSED_PARAMETER, org.acplt.oncrpc.OncRpcAuthStatus
			.ONCRPC_AUTH_OK)
		{
		}

		/// <summary>
		/// Constructs an <code>OncRpcAcceptedCallMessage</code> object for an
		/// accepted call with an unsupported version.
		/// </summary>
		/// <remarks>
		/// Constructs an <code>OncRpcAcceptedCallMessage</code> object for an
		/// accepted call with an unsupported version. The reply will contain
		/// information about the lowest and highest supported version.
		/// </remarks>
		/// <param name="call">
		/// The call message header, which is used to construct the
		/// matching reply message header from.
		/// </param>
		/// <param name="low">Lowest program version supported by this ONC/RPC server.</param>
		/// <param name="high">Highest program version supported by this ONC/RPC server.</param>
		public OncRpcServerAcceptedCallMessage(org.acplt.oncrpc.server.OncRpcServerCallMessage
			 call, int low, int high) : base(call, org.acplt.oncrpc.OncRpcReplyStatus.ONCRPC_MSG_ACCEPTED
			, org.acplt.oncrpc.OncRpcAcceptStatus.ONCRPC_PROG_MISMATCH, org.acplt.oncrpc.OncRpcReplyMessage
			.UNUSED_PARAMETER, low, high, org.acplt.oncrpc.OncRpcAuthStatus.ONCRPC_AUTH_OK)
		{
		}
	}
}
