namespace org.acplt.oncrpc
{
	/// <summary>
	/// A collection of constants used to identify the authentication status
	/// (or any authentication errors) in ONC/RPC replies of the corresponding
	/// ONC/RPC calls.
	/// </summary>
	/// <remarks>
	/// A collection of constants used to identify the authentication status
	/// (or any authentication errors) in ONC/RPC replies of the corresponding
	/// ONC/RPC calls.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:40 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcAuthStatus
	{
		/// <summary>There is no authentication problem or error.</summary>
		/// <remarks>There is no authentication problem or error.</remarks>
		public const int ONCRPC_AUTH_OK = 0;

		/// <summary>
		/// The ONC/RPC server detected a bad credential (that is, the seal was
		/// broken).
		/// </summary>
		/// <remarks>
		/// The ONC/RPC server detected a bad credential (that is, the seal was
		/// broken).
		/// </remarks>
		public const int ONCRPC_AUTH_BADCRED = 1;

		/// <summary>
		/// The ONC/RPC server has rejected the credential and forces the caller
		/// to begin a new session.
		/// </summary>
		/// <remarks>
		/// The ONC/RPC server has rejected the credential and forces the caller
		/// to begin a new session.
		/// </remarks>
		public const int ONCRPC_AUTH_REJECTEDCRED = 2;

		/// <summary>
		/// The ONC/RPC server detected a bad verifier (that is, the seal was
		/// broken).
		/// </summary>
		/// <remarks>
		/// The ONC/RPC server detected a bad verifier (that is, the seal was
		/// broken).
		/// </remarks>
		public const int ONCRPC_AUTH_BADVERF = 3;

		/// <summary>
		/// The ONC/RPC server detected an expired verifier (which can also happen
		/// if the verifier was replayed).
		/// </summary>
		/// <remarks>
		/// The ONC/RPC server detected an expired verifier (which can also happen
		/// if the verifier was replayed).
		/// </remarks>
		public const int ONCRPC_AUTH_REJECTEDVERF = 4;

		/// <summary>The ONC/RPC server rejected the authentication for security reasons.</summary>
		/// <remarks>The ONC/RPC server rejected the authentication for security reasons.</remarks>
		public const int ONCRPC_AUTH_TOOWEAK = 5;

		/// <summary>The ONC/RPC client detected a bogus response verifier.</summary>
		/// <remarks>The ONC/RPC client detected a bogus response verifier.</remarks>
		public const int ONCRPC_AUTH_INVALIDRESP = 6;

		/// <summary>Authentication at the ONC/RPC client failed for an unknown reason.</summary>
		/// <remarks>Authentication at the ONC/RPC client failed for an unknown reason.</remarks>
		public const int ONCRPC_AUTH_FAILED = 7;
	}
}
