namespace org.acplt.oncrpc
{
	/// <summary>
	/// The <code>OncRpcReplyMessage</code> class represents an ONC/RPC reply
	/// message as defined by ONC/RPC in RFC 1831.
	/// </summary>
	/// <remarks>
	/// The <code>OncRpcReplyMessage</code> class represents an ONC/RPC reply
	/// message as defined by ONC/RPC in RFC 1831. Such messages are sent back by
	/// ONC/RPC to servers to clients and contain (in case of real success) the
	/// result of a remote procedure call.
	/// <p>The decision to define only one single class for the accepted and
	/// rejected replies was driven by the motivation not to use polymorphism
	/// and thus have to upcast and downcast references all the time.
	/// <p>The derived classes are only provided for convinience on the server
	/// side.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:40 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcClientReplyMessage : org.acplt.oncrpc.OncRpcReplyMessage
	{
		/// <summary>
		/// Initializes a new <code>OncRpcReplyMessage</code> object to represent
		/// an invalid state.
		/// </summary>
		/// <remarks>
		/// Initializes a new <code>OncRpcReplyMessage</code> object to represent
		/// an invalid state. This default constructor should only be used if in the
		/// next step the real state of the reply message is immediately decoded
		/// from a XDR stream.
		/// </remarks>
		/// <param name="auth">
		/// Client-side authentication protocol handling object which
		/// is to be used when decoding the verifier data contained in the reply.
		/// </param>
		public OncRpcClientReplyMessage(org.acplt.oncrpc.OncRpcClientAuth auth) : base()
		{
			this.auth = auth;
		}

		/// <summary>
		/// Check whether this <code>OncRpcReplyMessage</code> represents an
		/// accepted and successfully executed remote procedure call.
		/// </summary>
		/// <remarks>
		/// Check whether this <code>OncRpcReplyMessage</code> represents an
		/// accepted and successfully executed remote procedure call.
		/// </remarks>
		/// <returns>
		/// <code>true</code> if remote procedure call was accepted and
		/// successfully executed.
		/// </returns>
		public virtual bool successfullyAccepted()
		{
			return (replyStatus == org.acplt.oncrpc.OncRpcReplyStatus.ONCRPC_MSG_ACCEPTED) &&
				 (acceptStatus == org.acplt.oncrpc.OncRpcAcceptStatus.ONCRPC_SUCCESS);
		}

		/// <summary>
		/// Return an appropriate exception object according to the state this
		/// reply message header object is in.
		/// </summary>
		/// <remarks>
		/// Return an appropriate exception object according to the state this
		/// reply message header object is in. The exception object then can be
		/// thrown.
		/// </remarks>
		/// <returns>
		/// Exception object of class
		/// <see cref="OncRpcException">OncRpcException</see>
		/// or a subclass
		/// thereof.
		/// </returns>
		public virtual org.acplt.oncrpc.OncRpcException newException()
		{
			switch (replyStatus)
			{
				case org.acplt.oncrpc.OncRpcReplyStatus.ONCRPC_MSG_ACCEPTED:
				{
					switch (acceptStatus)
					{
						case org.acplt.oncrpc.OncRpcAcceptStatus.ONCRPC_SUCCESS:
						{
							return new org.acplt.oncrpc.OncRpcException(org.acplt.oncrpc.OncRpcException.RPC_SUCCESS
								);
						}

						case org.acplt.oncrpc.OncRpcAcceptStatus.ONCRPC_PROC_UNAVAIL:
						{
							return new org.acplt.oncrpc.OncRpcException(org.acplt.oncrpc.OncRpcException.RPC_PROCUNAVAIL
								);
						}

						case org.acplt.oncrpc.OncRpcAcceptStatus.ONCRPC_PROG_MISMATCH:
						{
							return new org.acplt.oncrpc.OncRpcException(org.acplt.oncrpc.OncRpcException.RPC_PROGVERSMISMATCH
								);
						}

						case org.acplt.oncrpc.OncRpcAcceptStatus.ONCRPC_PROG_UNAVAIL:
						{
							return new org.acplt.oncrpc.OncRpcException(org.acplt.oncrpc.OncRpcException.RPC_PROGUNAVAIL
								);
						}

						case org.acplt.oncrpc.OncRpcAcceptStatus.ONCRPC_GARBAGE_ARGS:
						{
							return new org.acplt.oncrpc.OncRpcException(org.acplt.oncrpc.OncRpcException.RPC_CANTDECODEARGS
								);
						}

						case org.acplt.oncrpc.OncRpcAcceptStatus.ONCRPC_SYSTEM_ERR:
						{
							return new org.acplt.oncrpc.OncRpcException(org.acplt.oncrpc.OncRpcException.RPC_SYSTEMERROR
								);
						}
					}
					break;
				}

				case org.acplt.oncrpc.OncRpcReplyStatus.ONCRPC_MSG_DENIED:
				{
					switch (rejectStatus)
					{
						case org.acplt.oncrpc.OncRpcRejectStatus.ONCRPC_AUTH_ERROR:
						{
							return new org.acplt.oncrpc.OncRpcAuthenticationException(authStatus);
						}

						case org.acplt.oncrpc.OncRpcRejectStatus.ONCRPC_RPC_MISMATCH:
						{
							return new org.acplt.oncrpc.OncRpcException(org.acplt.oncrpc.OncRpcException.RPC_FAILED
								);
						}
					}
					break;
				}
			}
			return new org.acplt.oncrpc.OncRpcException();
		}

		/// <summary>
		/// Decodes -- that is: deserializes -- a ONC/RPC message header object
		/// from a XDR stream.
		/// </summary>
		/// <remarks>
		/// Decodes -- that is: deserializes -- a ONC/RPC message header object
		/// from a XDR stream.
		/// </remarks>
		/// <exception cref="OncRpcException">if an ONC/RPC error occurs.</exception>
		/// <exception cref="System.IO.IOException">if an I/O error occurs.</exception>
		/// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
		public virtual void xdrDecode(org.acplt.oncrpc.XdrDecodingStream xdr)
		{
			messageId = xdr.xdrDecodeInt();
			//
			// Make sure that we are really decoding an ONC/RPC message call
			// header. Otherwise, throw the appropriate OncRpcException exception.
			//
			messageType = xdr.xdrDecodeInt();
			if (messageType != org.acplt.oncrpc.OncRpcMessageType.ONCRPC_REPLY)
			{
				throw (new org.acplt.oncrpc.OncRpcException(org.acplt.oncrpc.OncRpcException.RPC_WRONGMESSAGE
					));
			}
			replyStatus = xdr.xdrDecodeInt();
			switch (replyStatus)
			{
				case org.acplt.oncrpc.OncRpcReplyStatus.ONCRPC_MSG_ACCEPTED:
				{
					//
					// Decode the information returned for accepted message calls.
					// If we have an associated client-side authentication protocol
					// object, we use that. Otherwise we fall back to the default
					// handling of only the AUTH_NONE authentication.
					//
					if (auth != null)
					{
						auth.xdrDecodeVerf(xdr);
					}
					else
					{
						//
						// If we don't have a protocol handler and the server sent its
						// reply using another authentication scheme than AUTH_NONE, we
						// will throw an exception. Also we check that no-one is
						// actually sending opaque information within AUTH_NONE.
						//
						if (xdr.xdrDecodeInt() != org.acplt.oncrpc.OncRpcAuthType.ONCRPC_AUTH_NONE)
						{
							throw (new org.acplt.oncrpc.OncRpcAuthenticationException(org.acplt.oncrpc.OncRpcAuthStatus
								.ONCRPC_AUTH_FAILED));
						}
						if (xdr.xdrDecodeInt() != 0)
						{
							throw (new org.acplt.oncrpc.OncRpcAuthenticationException(org.acplt.oncrpc.OncRpcAuthStatus
								.ONCRPC_AUTH_FAILED));
						}
					}
					//
					// Even if the call was accepted by the server, it can still
					// indicate an error. Depending on the status of the accepted
					// call we will receive an indication about the range of
					// versions a particular program (server) supports.
					//
					acceptStatus = xdr.xdrDecodeInt();
					switch (acceptStatus)
					{
						case org.acplt.oncrpc.OncRpcAcceptStatus.ONCRPC_PROG_MISMATCH:
						{
							lowVersion = xdr.xdrDecodeInt();
							highVersion = xdr.xdrDecodeInt();
							break;
						}

						default:
						{
							//
							// Otherwise "open ended set of problem", like the author
							// of Sun's ONC/RPC source once wrote...
							//
							break;
						}
					}
					break;
				}

				case org.acplt.oncrpc.OncRpcReplyStatus.ONCRPC_MSG_DENIED:
				{
					//
					// Encode the information returned for denied message calls.
					//
					rejectStatus = xdr.xdrDecodeInt();
					switch (rejectStatus)
					{
						case org.acplt.oncrpc.OncRpcRejectStatus.ONCRPC_RPC_MISMATCH:
						{
							lowVersion = xdr.xdrDecodeInt();
							highVersion = xdr.xdrDecodeInt();
							break;
						}

						case org.acplt.oncrpc.OncRpcRejectStatus.ONCRPC_AUTH_ERROR:
						{
							authStatus = xdr.xdrDecodeInt();
							break;
						}

						default:
						{
							break;
						}
					}
					break;
				}
			}
		}

		/// <summary>
		/// Client-side authentication protocol handling object to use when
		/// decoding the reply message.
		/// </summary>
		/// <remarks>
		/// Client-side authentication protocol handling object to use when
		/// decoding the reply message.
		/// </remarks>
		internal org.acplt.oncrpc.OncRpcClientAuth auth;
	}
}
