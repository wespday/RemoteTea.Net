namespace org.acplt.oncrpc
{
	/// <summary>
	/// The <code>OncRpcClientAuthNone</code> class handles protocol issues of
	/// ONC/RPC <code>AUTH_NONE</code> authentication.
	/// </summary>
	/// <remarks>
	/// The <code>OncRpcClientAuthNone</code> class handles protocol issues of
	/// ONC/RPC <code>AUTH_NONE</code> authentication.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:40 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcClientAuthNone : org.acplt.oncrpc.OncRpcClientAuth
	{
		/// <summary>
		/// Encodes ONC/RPC authentication information in form of a credential
		/// and a verifier when sending an ONC/RPC call message.
		/// </summary>
		/// <remarks>
		/// Encodes ONC/RPC authentication information in form of a credential
		/// and a verifier when sending an ONC/RPC call message.
		/// </remarks>
		/// <param name="xdr">
		/// XDR stream where to encode the credential and the verifier
		/// to.
		/// </param>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		internal override void xdrEncodeCredVerf(org.acplt.oncrpc.XdrEncodingStream xdr)
		{
			//
			// The credential only consists of the indication of AUTH_NONE with
			// no opaque authentication data following.
			//
			xdr.xdrEncodeInt(org.acplt.oncrpc.OncRpcAuthType.ONCRPC_AUTH_NONE);
			xdr.xdrEncodeInt(0);
			//
			// But we also need to encode the verifier. This is always of type
			// AUTH_NONE too. For some obscure historical reasons, we have to
			// deal with credentials and verifiers, although they belong together,
			// according to Sun's specification.
			//
			xdr.xdrEncodeInt(org.acplt.oncrpc.OncRpcAuthType.ONCRPC_AUTH_NONE);
			xdr.xdrEncodeInt(0);
		}

		/// <summary>
		/// Decodes ONC/RPC authentication information in form of a verifier
		/// when receiving an ONC/RPC reply message.
		/// </summary>
		/// <remarks>
		/// Decodes ONC/RPC authentication information in form of a verifier
		/// when receiving an ONC/RPC reply message.
		/// </remarks>
		/// <param name="xdr">
		/// XDR stream from which to receive the verifier sent together
		/// with an ONC/RPC reply message.
		/// </param>
		/// <exception cref="OncRpcAuthenticationException">
		/// if the received verifier is
		/// not kosher.
		/// </exception>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		internal override void xdrDecodeVerf(org.acplt.oncrpc.XdrDecodingStream xdr)
		{
			//
			// Make sure that we received a AUTH_NONE verifier and that it
			// does not contain any opaque data. Anything different from this
			// is not kosher and an authentication exception will be thrown.
			//
			if ((xdr.xdrDecodeInt() != org.acplt.oncrpc.OncRpcAuthType.ONCRPC_AUTH_NONE) || (
				xdr.xdrDecodeInt() != 0))
			{
				throw (new org.acplt.oncrpc.OncRpcAuthenticationException(org.acplt.oncrpc.OncRpcAuthStatus
					.ONCRPC_AUTH_FAILED));
			}
		}

		/// <summary>
		/// Indicates whether the ONC/RPC authentication credential can be
		/// refreshed.
		/// </summary>
		/// <remarks>
		/// Indicates whether the ONC/RPC authentication credential can be
		/// refreshed.
		/// </remarks>
		/// <returns>true, if the credential can be refreshed</returns>
		public override bool canRefreshCred()
		{
			//
			// Nothing to do here, as AUTH_NONE doesn't know anything of
			// credential refreshing. How refreshing...
			//
			return false;
		}

		/// <summary>
		/// Contains a singleton which comes in handy if you just need an
		/// AUTH_NONE authentification for an ONC/RPC client.
		/// </summary>
		/// <remarks>
		/// Contains a singleton which comes in handy if you just need an
		/// AUTH_NONE authentification for an ONC/RPC client.
		/// </remarks>
		public static readonly org.acplt.oncrpc.OncRpcClientAuthNone AUTH_NONE = new org.acplt.oncrpc.OncRpcClientAuthNone
			();
	}
}
