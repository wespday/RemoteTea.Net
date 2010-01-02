namespace org.acplt.oncrpc
{
	/// <summary>
	/// Instances of the class <code>XdrInt</code> represent (de-)serializeable
	/// integers, which are especially useful in cases where a result with only a
	/// single int is expected from a remote function call or only a single
	/// int parameter needs to be supplied.
	/// </summary>
	/// <remarks>
	/// Instances of the class <code>XdrInt</code> represent (de-)serializeable
	/// integers, which are especially useful in cases where a result with only a
	/// single int is expected from a remote function call or only a single
	/// int parameter needs to be supplied.
	/// <p>Please note that this class is somewhat modelled after Java's primitive
	/// data type wrappers. As for these classes, the XDR data type wrapper classes
	/// follow the concept of values with no identity, so you are not allowed to
	/// change the value after you've created a value object.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:40 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class XdrInt : org.acplt.oncrpc.XdrAble
	{
		/// <summary>Constructs and initializes a new <code>XdrInt</code> object.</summary>
		/// <remarks>Constructs and initializes a new <code>XdrInt</code> object.</remarks>
		/// <param name="value">Int value.</param>
		public XdrInt(int value)
		{
			this.value = value;
		}

		/// <summary>Constructs and initializes a new <code>XdrInt</code> object.</summary>
		/// <remarks>Constructs and initializes a new <code>XdrInt</code> object.</remarks>
		public XdrInt()
		{
			this.value = 0;
		}

		/// <summary>
		/// Returns the value of this <code>XdrInt</code> object as a int
		/// primitive.
		/// </summary>
		/// <remarks>
		/// Returns the value of this <code>XdrInt</code> object as a int
		/// primitive.
		/// </remarks>
		/// <returns>The primitive <code>int</code> value of this object.</returns>
		public virtual int intValue()
		{
			return this.value;
		}

		/// <summary>
		/// Encodes -- that is: serializes -- a XDR int into a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Encodes -- that is: serializes -- a XDR int into a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrEncode(org.acplt.oncrpc.XdrEncodingStream xdr)
		{
			xdr.xdrEncodeInt(value);
		}

		/// <summary>
		/// Decodes -- that is: deserializes -- a XDR int from a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Decodes -- that is: deserializes -- a XDR int from a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrDecode(org.acplt.oncrpc.XdrDecodingStream xdr)
		{
			value = xdr.xdrDecodeInt();
		}

		/// <summary>The encapsulated int value itself.</summary>
		/// <remarks>The encapsulated int value itself.</remarks>
		private int value;
	}
}
