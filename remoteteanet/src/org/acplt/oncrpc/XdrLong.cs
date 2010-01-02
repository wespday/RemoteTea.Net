namespace org.acplt.oncrpc
{
	/// <summary>
	/// Instances of the class <code>XdrLong</code> represent (de-)serializeable
	/// longs (64&nbsp;bit), which are especially useful in cases where a result with only a
	/// single long is expected from a remote function call or only a single
	/// long parameter needs to be supplied.
	/// </summary>
	/// <remarks>
	/// Instances of the class <code>XdrLong</code> represent (de-)serializeable
	/// longs (64&nbsp;bit), which are especially useful in cases where a result with only a
	/// single long is expected from a remote function call or only a single
	/// long parameter needs to be supplied.
	/// <p>Please note that this class is somewhat modelled after Java's primitive
	/// data type wrappers. As for these classes, the XDR data type wrapper classes
	/// follow the concept of values with no identity, so you are not allowed to
	/// change the value after you've created a value object.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:40 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class XdrLong : org.acplt.oncrpc.XdrAble
	{
		/// <summary>Constructs and initializes a new <code>XdrLong</code> object.</summary>
		/// <remarks>Constructs and initializes a new <code>XdrLong</code> object.</remarks>
		/// <param name="value">Long value.</param>
		public XdrLong(long value)
		{
			this.value = value;
		}

		/// <summary>Constructs and initializes a new <code>XdrLong</code> object.</summary>
		/// <remarks>Constructs and initializes a new <code>XdrLong</code> object.</remarks>
		public XdrLong()
		{
			this.value = 0;
		}

		/// <summary>
		/// Returns the value of this <code>XdrLong</code> object as a long
		/// primitive.
		/// </summary>
		/// <remarks>
		/// Returns the value of this <code>XdrLong</code> object as a long
		/// primitive.
		/// </remarks>
		/// <returns>The primitive <code>long</code> value of this object.</returns>
		public virtual long longValue()
		{
			return this.value;
		}

		/// <summary>
		/// Encodes -- that is: serializes -- a XDR long into a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Encodes -- that is: serializes -- a XDR long into a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrEncode(org.acplt.oncrpc.XdrEncodingStream xdr)
		{
			xdr.xdrEncodeLong(value);
		}

		/// <summary>
		/// Decodes -- that is: deserializes -- a XDR long from a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Decodes -- that is: deserializes -- a XDR long from a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrDecode(org.acplt.oncrpc.XdrDecodingStream xdr)
		{
			value = xdr.xdrDecodeLong();
		}

		/// <summary>The encapsulated long value itself.</summary>
		/// <remarks>The encapsulated long value itself.</remarks>
		private long value;
	}
}
