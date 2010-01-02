namespace org.acplt.oncrpc
{
	/// <summary>
	/// Instances of the class <code>XdrVoid</code> represent (de-)serializeable
	/// voids, which are especially useful in cases where no result is expected
	/// from a remote function call or no parameters are supplied.
	/// </summary>
	/// <remarks>
	/// Instances of the class <code>XdrVoid</code> represent (de-)serializeable
	/// voids, which are especially useful in cases where no result is expected
	/// from a remote function call or no parameters are supplied.
	/// <p>Please note that this class is somewhat modelled after Java's primitive
	/// data type wrappers. As for these classes, the XDR data type wrapper classes
	/// follow the concept of values with no identity, so you are not allowed to
	/// change the value after you've created a value object.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:41 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class XdrVoid : org.acplt.oncrpc.XdrAble
	{
		/// <summary>
		/// Encodes -- that is: serializes -- a void into a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Encodes -- that is: serializes -- a void into a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrEncode(org.acplt.oncrpc.XdrEncodingStream xdr)
		{
		}

		/// <summary>
		/// Decodes -- that is: deserializes -- a void from a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Decodes -- that is: deserializes -- a void from a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrDecode(org.acplt.oncrpc.XdrDecodingStream xdr)
		{
		}

		/// <summary>
		/// Static <code>XdrVoid</code> instance, which can be used in cases
		/// where no data is to be serialized or deserialized but some ONC/RPC
		/// function expects a reference to a XDR-able object.
		/// </summary>
		/// <remarks>
		/// Static <code>XdrVoid</code> instance, which can be used in cases
		/// where no data is to be serialized or deserialized but some ONC/RPC
		/// function expects a reference to a XDR-able object.
		/// </remarks>
		public static readonly org.acplt.oncrpc.XdrVoid XDR_VOID = new org.acplt.oncrpc.XdrVoid
			();
	}
}
