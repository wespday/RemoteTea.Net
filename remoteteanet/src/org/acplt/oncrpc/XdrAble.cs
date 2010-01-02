namespace org.acplt.oncrpc
{
	/// <summary>
	/// Defines the interface for all classes that should be able to be
	/// serialized into XDR streams, and deserialized or constructed from
	/// XDR streams.
	/// </summary>
	/// <remarks>
	/// Defines the interface for all classes that should be able to be
	/// serialized into XDR streams, and deserialized or constructed from
	/// XDR streams.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:43 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public interface XdrAble
	{
		/// <summary>
		/// Encodes -- that is: serializes -- an object into a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Encodes -- that is: serializes -- an object into a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <param name="xdr">XDR stream to which information is sent for encoding.</param>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		void xdrEncode(org.acplt.oncrpc.XdrEncodingStream xdr);

		/// <summary>
		/// Decodes -- that is: deserializes -- an object from a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Decodes -- that is: deserializes -- an object from a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <param name="xdr">XDR stream from which decoded information is retrieved.</param>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		void xdrDecode(org.acplt.oncrpc.XdrDecodingStream xdr);
	}
}
