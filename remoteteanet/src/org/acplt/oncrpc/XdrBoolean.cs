namespace org.acplt.oncrpc
{
	/// <summary>
	/// Instances of the class <code>XdrBoolean</code> represent (de-)serializeable
	/// booleans, which are especially useful in cases where a result with only a
	/// single boolean is expected from a remote function call or only a single
	/// boolean parameter needs to be supplied.
	/// </summary>
	/// <remarks>
	/// Instances of the class <code>XdrBoolean</code> represent (de-)serializeable
	/// booleans, which are especially useful in cases where a result with only a
	/// single boolean is expected from a remote function call or only a single
	/// boolean parameter needs to be supplied.
	/// <p>Please note that this class is somewhat modelled after Java's primitive
	/// data type wrappers. As for these classes, the XDR data type wrapper classes
	/// follow the concept of values with no identity, so you are not allowed to
	/// change the value after you've created a value object.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:43 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class XdrBoolean : org.acplt.oncrpc.XdrAble
	{
		/// <summary>Constructs and initializes a new <code>XdrBoolean</code> object.</summary>
		/// <remarks>Constructs and initializes a new <code>XdrBoolean</code> object.</remarks>
		/// <param name="value">Boolean value.</param>
		public XdrBoolean(bool value)
		{
			this.value = value;
		}

		/// <summary>Constructs and initializes a new <code>XdrBoolean</code> object.</summary>
		/// <remarks>Constructs and initializes a new <code>XdrBoolean</code> object.</remarks>
		public XdrBoolean()
		{
			this.value = false;
		}

        /// <summary>
        /// Returns the value of this <code>XdrBoolean</code> object as a boolean
        /// primitive.
        /// </summary>
        /// <remarks>
        /// Returns the value of this <code>XdrBoolean</code> object as a boolean
        /// primitive.
        /// </remarks>
        /// <returns>The primitive <code>boolean</code> value of this object.</returns>
        public virtual bool booleanValue()
        {
            return this.value;
        }

        /// <summary>
        /// Returns the value of this <code>XdrBoolean</code> object as a boolean
        /// primitive.
        /// </summary>
        /// <remarks>
        /// Returns the value of this <code>XdrBoolean</code> object as a boolean
        /// primitive.
        /// </remarks>
        /// <returns>The primitive <code>boolean</code> value of this object.</returns>
        public virtual bool boolValue()
        {
            return this.value;
        }

        /// <summary>
		/// Encodes -- that is: serializes -- a XDR boolean into a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Encodes -- that is: serializes -- a XDR boolean into a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrEncode(org.acplt.oncrpc.XdrEncodingStream xdr)
		{
			xdr.xdrEncodeBoolean(value);
		}

		/// <summary>
		/// Decodes -- that is: deserializes -- a XDR boolean from a XDR stream in
		/// compliance to RFC 1832.
		/// </summary>
		/// <remarks>
		/// Decodes -- that is: deserializes -- a XDR boolean from a XDR stream in
		/// compliance to RFC 1832.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrDecode(org.acplt.oncrpc.XdrDecodingStream xdr)
		{
			value = xdr.xdrDecodeBoolean();
		}

		/// <summary>The encapsulated boolean value itself.</summary>
		/// <remarks>The encapsulated boolean value itself.</remarks>
		private bool value;
	}
}
