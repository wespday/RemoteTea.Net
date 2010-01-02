namespace org.acplt.oncrpc
{
	/// <summary>
	/// The <code>OncRpcGetPortResult</code> class represents the result from
	/// a PMAP_GETPORT remote procedure call to the ONC/RPC portmapper.
	/// </summary>
	/// <remarks>
	/// The <code>OncRpcGetPortResult</code> class represents the result from
	/// a PMAP_GETPORT remote procedure call to the ONC/RPC portmapper.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:41 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcGetPortResult : org.acplt.oncrpc.XdrAble
	{
		/// <summary>The port number of the ONC/RPC in question.</summary>
		/// <remarks>
		/// The port number of the ONC/RPC in question. This is the only interesting
		/// piece of information in this class. Go live with it, you don't have
		/// alternatives.
		/// </remarks>
		public int port;

		/// <summary>
		/// Default constructor for initializing an <code>OncRpcGetPortParams</code>
		/// result object.
		/// </summary>
		/// <remarks>
		/// Default constructor for initializing an <code>OncRpcGetPortParams</code>
		/// result object. It sets the <code>port</code> member to a useless value.
		/// </remarks>
		public OncRpcGetPortResult()
		{
			port = 0;
		}

		/// <summary>
		/// Encodes -- that is: serializes -- an <code>OncRpcGetPortParams</code>
		/// object into a XDR stream.
		/// </summary>
		/// <remarks>
		/// Encodes -- that is: serializes -- an <code>OncRpcGetPortParams</code>
		/// object into a XDR stream.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrEncode(org.acplt.oncrpc.XdrEncodingStream xdr)
		{
			xdr.xdrEncodeInt(port);
		}

		/// <summary>
		/// Decodes -- that is: deserializes -- an <code>OncRpcGetPortParams</code>
		/// object from a XDR stream.
		/// </summary>
		/// <remarks>
		/// Decodes -- that is: deserializes -- an <code>OncRpcGetPortParams</code>
		/// object from a XDR stream.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrDecode(org.acplt.oncrpc.XdrDecodingStream xdr)
		{
			port = xdr.xdrDecodeInt();
		}
	}
}
