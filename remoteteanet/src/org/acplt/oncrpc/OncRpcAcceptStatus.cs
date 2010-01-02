namespace org.acplt.oncrpc
{
	/// <summary>
	/// A collection of constants used to identify the acceptance status of
	/// ONC/RPC reply messages.
	/// </summary>
	/// <remarks>
	/// A collection of constants used to identify the acceptance status of
	/// ONC/RPC reply messages.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:39 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcAcceptStatus
	{
		/// <summary>The remote procedure was called and executed successfully.</summary>
		/// <remarks>The remote procedure was called and executed successfully.</remarks>
		public const int ONCRPC_SUCCESS = 0;

		/// <summary>The program requested is not available.</summary>
		/// <remarks>
		/// The program requested is not available. So the remote host
		/// does not export this particular program and the ONC/RPC server
		/// which you tried to send a RPC call message doesn't know of this
		/// program either.
		/// </remarks>
		public const int ONCRPC_PROG_UNAVAIL = 1;

		/// <summary>A program version number mismatch occured.</summary>
		/// <remarks>
		/// A program version number mismatch occured. The remote ONC/RPC
		/// server does not support this particular version of the program.
		/// </remarks>
		public const int ONCRPC_PROG_MISMATCH = 2;

		/// <summary>The procedure requested is not available.</summary>
		/// <remarks>
		/// The procedure requested is not available. The remote ONC/RPC server
		/// does not support this particular procedure.
		/// </remarks>
		public const int ONCRPC_PROC_UNAVAIL = 3;

		/// <summary>
		/// The server could not decode the arguments sent within the ONC/RPC
		/// call message.
		/// </summary>
		/// <remarks>
		/// The server could not decode the arguments sent within the ONC/RPC
		/// call message.
		/// </remarks>
		public const int ONCRPC_GARBAGE_ARGS = 4;

		/// <summary>
		/// The server encountered a system error and thus was not able to
		/// process the procedure call.
		/// </summary>
		/// <remarks>
		/// The server encountered a system error and thus was not able to
		/// process the procedure call. Causes might be memory shortage,
		/// desinterest and sloth.
		/// </remarks>
		public const int ONCRPC_SYSTEM_ERR = 5;
	}
}
