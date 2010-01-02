namespace org.acplt.oncrpc
{
	/// <summary>
	/// The class <code>OncRpcTimeoutException</code> indicates a timed out
	/// call exception.
	/// </summary>
	/// <remarks>
	/// The class <code>OncRpcTimeoutException</code> indicates a timed out
	/// call exception.
	/// </remarks>
	/// <version>$Revision: 1.2 $ $Date: 2005/11/11 21:05:00 $ $State: Exp $ $Locker:  $</version>
	/// <author>Harald Albrecht</author>
	[System.Serializable]
	public class OncRpcTimeoutException : org.acplt.oncrpc.OncRpcException
	{
		/// <summary>Defines the serial version UID for <code>OncRpcTimeoutException</code>.</summary>
		/// <remarks>Defines the serial version UID for <code>OncRpcTimeoutException</code>.</remarks>
		private const long serialVersionUID = 2777518173161399732L;

		/// <summary>
		/// Initializes an <code>OncRpcTimeoutException</code>
		/// with a detail of
		/// <see cref="OncRpcException.RPC_TIMEDOUT">OncRpcException.RPC_TIMEDOUT</see>
		/// .
		/// </summary>
		public OncRpcTimeoutException() : base(RPC_TIMEDOUT)
		{
		}
	}
}
