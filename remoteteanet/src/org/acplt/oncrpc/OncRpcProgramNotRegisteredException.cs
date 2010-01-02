namespace org.acplt.oncrpc
{
	/// <summary>
	/// The class <code>OncRpcProgramNotRegisteredException</code> indicates
	/// that the requests ONC/RPC program is not available at the specified host.
	/// </summary>
	/// <remarks>
	/// The class <code>OncRpcProgramNotRegisteredException</code> indicates
	/// that the requests ONC/RPC program is not available at the specified host.
	/// </remarks>
	/// <version>$Revision: 1.2 $ $Date: 2005/11/11 21:03:30 $ $State: Exp $ $Locker:  $</version>
	/// <author>Harald Albrecht</author>
	[System.Serializable]
	public class OncRpcProgramNotRegisteredException : org.acplt.oncrpc.OncRpcException
	{
		/// <summary>Defines the serial version UID for <code>OncRpcProgramNotRegisteredException</code>.
		/// 	</summary>
		/// <remarks>Defines the serial version UID for <code>OncRpcProgramNotRegisteredException</code>.
		/// 	</remarks>
		private const long serialVersionUID = 5073156463000368270L;

		/// <summary>
		/// Constructs an ONC/RPC program not registered exception with a detail
		/// code of <code>OncRpcException.RPC_PROGNOTREGISTERED</code> and an
		/// appropriate clear-text detail message.
		/// </summary>
		/// <remarks>
		/// Constructs an ONC/RPC program not registered exception with a detail
		/// code of <code>OncRpcException.RPC_PROGNOTREGISTERED</code> and an
		/// appropriate clear-text detail message.
		/// </remarks>
		public OncRpcProgramNotRegisteredException() : base(org.acplt.oncrpc.OncRpcException
			.RPC_PROGNOTREGISTERED)
		{
		}
	}
}
