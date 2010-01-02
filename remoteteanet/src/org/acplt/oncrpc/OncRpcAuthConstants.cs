namespace org.acplt.oncrpc
{
	/// <summary>
	/// A collection of constants related to authentication and generally usefull
	/// for ONC/RPC.
	/// </summary>
	/// <remarks>
	/// A collection of constants related to authentication and generally usefull
	/// for ONC/RPC.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:40 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcAuthConstants
	{
		/// <summary>Maximum length of opaque authentication information.</summary>
		/// <remarks>Maximum length of opaque authentication information.</remarks>
		public const int ONCRPC_MAX_AUTH_BYTES = 400;

		/// <summary>Maximum length of machine name.</summary>
		/// <remarks>Maximum length of machine name.</remarks>
		public const int ONCRPC_MAX_MACHINE_NAME = 255;

		/// <summary>Maximum allowed number of groups.</summary>
		/// <remarks>Maximum allowed number of groups.</remarks>
		public const int ONCRPC_MAX_GROUPS = 16;
	}
}
