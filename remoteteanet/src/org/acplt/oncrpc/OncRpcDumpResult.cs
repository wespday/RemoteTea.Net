namespace org.acplt.oncrpc
{
	/// <summary>
	/// Objects of class <code>OncRpcDumpResult</code> represent the outcome of
	/// the PMAP_DUMP operation on a portmapper.
	/// </summary>
	/// <remarks>
	/// Objects of class <code>OncRpcDumpResult</code> represent the outcome of
	/// the PMAP_DUMP operation on a portmapper. <code>OncRpcDumpResult</code>s are
	/// (de-)serializeable, so they can be flushed down XDR streams.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:41 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcDumpResult : org.acplt.oncrpc.XdrAble
	{
		/// <summary>
		/// Vector of server ident objects describing the currently registered
		/// ONC/RPC servers (also known as "programmes").
		/// </summary>
		/// <remarks>
		/// Vector of server ident objects describing the currently registered
		/// ONC/RPC servers (also known as "programmes").
		/// </remarks>
		public System.Collections.ArrayList servers;

		/// <summary>Initialize an <code>OncRpcServerIdent</code> object.</summary>
		/// <remarks>
		/// Initialize an <code>OncRpcServerIdent</code> object. Afterwards, the
		/// <code>servers</code> field is initialized to contain no elements.
		/// </remarks>
		public OncRpcDumpResult()
		{
			servers = new System.Collections.ArrayList();
		}

		/// <summary>
		/// Encodes -- that is: serializes -- the result of a PMAP_DUMP operationg
		/// into a XDR stream.
		/// </summary>
		/// <remarks>
		/// Encodes -- that is: serializes -- the result of a PMAP_DUMP operationg
		/// into a XDR stream.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrEncode(org.acplt.oncrpc.XdrEncodingStream xdr)
		{
			if (servers == null)
			{
				xdr.xdrEncodeBoolean(false);
			}
			else
			{
				//
				// Now encode all server ident objects into the xdr stream. Each
				// object is preceeded by a boolan, which indicates to the receiver
				// whether an object follows. After the last object has been
				// encoded the receiver will find a boolean false in the stream.
				//
				int count = servers.Count;
				int index = 0;
				while (count > 0)
				{
					xdr.xdrEncodeBoolean(true);
					((org.acplt.oncrpc.XdrAble)servers[index]).xdrEncode(xdr);
					index++;
					count--;
				}
				xdr.xdrEncodeBoolean(false);
			}
		}

		/// <summary>
		/// Decodes -- that is: deserializes -- the result from a PMAP_DUMP remote
		/// procedure call from a XDR stream.
		/// </summary>
		/// <remarks>
		/// Decodes -- that is: deserializes -- the result from a PMAP_DUMP remote
		/// procedure call from a XDR stream.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrDecode(org.acplt.oncrpc.XdrDecodingStream xdr)
		{
			//
			// Calling removeAllElements() instead of clear() preserves
			// pre-JDK2 compatibility.
			//
			servers.Clear();
			//
			// Pull the server ident object off the xdr stream. Each object is
			// preceeded by a boolean value indicating whether there is still an
			// object in the pipe.
			//
			while (xdr.xdrDecodeBoolean())
			{
				servers.Add(new org.acplt.oncrpc.OncRpcServerIdent(xdr));
			}
		}
	}
}
