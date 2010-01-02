namespace org.acplt.oncrpc
{
	/// <summary>
	/// A collection of constants used to identify the authentication schemes
	/// available for ONC/RPC.
	/// </summary>
	/// <remarks>
	/// A collection of constants used to identify the authentication schemes
	/// available for ONC/RPC. Please note that currently only
	/// <code>ONCRPC_AUTH_NONE</code> is supported by this Java package.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:40 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcAuthType
	{
		/// <summary>No authentication scheme used for this remote procedure call.</summary>
		/// <remarks>No authentication scheme used for this remote procedure call.</remarks>
		public const int ONCRPC_AUTH_NONE = 0;

		/// <summary>The so-called "Unix" authentication scheme is not supported.</summary>
		/// <remarks>
		/// The so-called "Unix" authentication scheme is not supported. This one
		/// only sends the users id as well as her/his group identifiers, so this
		/// is simply far too weak to use in typical situations where
		/// authentication is requested.
		/// </remarks>
		public const int ONCRPC_AUTH_UNIX = 1;

		/// <summary>The so-called "short hand Unix style" is not supported.</summary>
		/// <remarks>The so-called "short hand Unix style" is not supported.</remarks>
		public const int ONCRPC_AUTH_SHORT = 2;

		/// <summary>
		/// The DES authentication scheme (using encrypted time stamps) is not
		/// supported -- and besides, it's not a silver bullet either.
		/// </summary>
		/// <remarks>
		/// The DES authentication scheme (using encrypted time stamps) is not
		/// supported -- and besides, it's not a silver bullet either.
		/// </remarks>
		public const int ONCRPC_AUTH_DES = 3;
	}
}
