namespace org.acplt.oncrpc
{
	/// <summary>
	/// The class <code>OncRpcAuthenticationException</code> indicates an
	/// authentication exception.
	/// </summary>
	/// <remarks>
	/// The class <code>OncRpcAuthenticationException</code> indicates an
	/// authentication exception.
	/// </remarks>
	/// <version>$Revision: 1.2 $ $Date: 2005/11/11 21:01:44 $ $State: Exp $ $Locker:  $</version>
	/// <author>Harald Albrecht</author>
	[System.Serializable]
	public class OncRpcAuthenticationException : org.acplt.oncrpc.OncRpcException
	{
		/// <summary>Defines the serial version UID for <code>OncRpcAuthenticationException</code>.
		/// 	</summary>
		/// <remarks>Defines the serial version UID for <code>OncRpcAuthenticationException</code>.
		/// 	</remarks>
		private const long serialVersionUID = 7747394107888423440L;

		/// <summary>
		/// Initializes an <code>OncRpcAuthenticationException</code>
		/// with a detail of
		/// <see cref="OncRpcException.RPC_AUTHERROR">OncRpcException.RPC_AUTHERROR</see>
		/// and
		/// the specified
		/// <see cref="OncRpcAuthStatus">authentication status</see>
		/// detail.
		/// </summary>
		/// <param name="authStatus">
		/// The authentication status, which can be any one of
		/// the
		/// <see cref="OncRpcAuthStatus">OncRpcAuthStatus constants</see>
		/// .
		/// </param>
		public OncRpcAuthenticationException(int authStatus) : base(RPC_AUTHERROR)
		{
			authStatusDetail = authStatus;
		}

		/// <summary>
		/// Returns the authentication status detail of this ONC/RPC exception
		/// object.
		/// </summary>
		/// <remarks>
		/// Returns the authentication status detail of this ONC/RPC exception
		/// object.
		/// </remarks>
		/// <returns>The authentication status of this <code>OncRpcException</code>.</returns>
		public virtual int getAuthStatus()
		{
			return authStatusDetail;
		}

		/// <summary>
		/// Specific authentication status detail (reason why this authentication
		/// exception was thrown).
		/// </summary>
		/// <remarks>
		/// Specific authentication status detail (reason why this authentication
		/// exception was thrown).
		/// </remarks>
		/// <serial></serial>
		private int authStatusDetail;
	}
}
