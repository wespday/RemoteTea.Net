namespace org.acplt.oncrpc
{
	/// <summary>
	/// Instances of the class <code>XdrFloat</code> represent (de-)serializeable
	/// floats, which are especially useful in cases where a result with only a
	/// single float is expected from a remote function call or only a single
	/// float parameter needs to be supplied.
	/// </summary>
	/// <remarks>
	/// Instances of the class <code>XdrFloat</code> represent (de-)serializeable
	/// floats, which are especially useful in cases where a result with only a
	/// single float is expected from a remote function call or only a single
	/// float parameter needs to be supplied.
	/// <p>Please note that this class is somewhat modelled after Java's primitive
	/// data type wrappers. As for these classes, the XDR data type wrapper classes
	/// follow the concept of values with no identity, so you are not allowed to
	/// change the value after you've created a value object.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:40 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class XdrFloat : org.acplt.oncrpc.XdrAble
	{
		/// <summary>Constructs and initializes a new <code>XdrFloat</code> object.</summary>
		/// <remarks>Constructs and initializes a new <code>XdrFloat</code> object.</remarks>
		/// <param name="value">Float value.</param>
		public XdrFloat(float value)
		{
			this.value = value;
		}

		/// <summary>Constructs and initializes a new <code>XdrFloat</code> object.</summary>
		/// <remarks>Constructs and initializes a new <code>XdrFloat</code> object.</remarks>
		public XdrFloat()
		{
			this.value = 0;
		}

		/// <summary>
		/// Returns the value of this <code>XdrFloat</code> object as a float
		/// primitive.
		/// </summary>
		/// <remarks>
		/// Returns the value of this <code>XdrFloat</code> object as a float
		/// primitive.
		/// </remarks>
		/// <returns>The primitive <code>float</code> value of this object.</returns>
		public virtual float floatValue()
		{
			return this.value;
		}

		/// <summary>
		/// Encodes -- that is: serializes -- a XDR float into a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Encodes -- that is: serializes -- a XDR float into a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrEncode(org.acplt.oncrpc.XdrEncodingStream xdr)
		{
			xdr.xdrEncodeFloat(value);
		}

		/// <summary>
		/// Decodes -- that is: deserializes -- a XDR float from a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Decodes -- that is: deserializes -- a XDR float from a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrDecode(org.acplt.oncrpc.XdrDecodingStream xdr)
		{
			value = xdr.xdrDecodeFloat();
		}

		/// <summary>The encapsulated float value itself.</summary>
		/// <remarks>The encapsulated float value itself.</remarks>
		private float value;
	}
}
