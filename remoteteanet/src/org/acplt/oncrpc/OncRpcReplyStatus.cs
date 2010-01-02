namespace org.acplt.oncrpc
{
	/// <summary>
	/// A collection of constants used to identify the (overall) status of an
	/// ONC/RPC reply message.
	/// </summary>
	/// <remarks>
	/// A collection of constants used to identify the (overall) status of an
	/// ONC/RPC reply message.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:41 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcReplyStatus
	{
		/// <summary>
		/// Reply status identifying that the corresponding message call was
		/// accepted.
		/// </summary>
		/// <remarks>
		/// Reply status identifying that the corresponding message call was
		/// accepted.
		/// </remarks>
		public const int ONCRPC_MSG_ACCEPTED = 0;

		/// <summary>
		/// Reply status identifying that the corresponding message call was
		/// denied.
		/// </summary>
		/// <remarks>
		/// Reply status identifying that the corresponding message call was
		/// denied.
		/// </remarks>
		public const int ONCRPC_MSG_DENIED = 1;
	}
}
