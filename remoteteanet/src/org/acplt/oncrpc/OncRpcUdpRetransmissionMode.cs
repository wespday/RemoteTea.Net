namespace org.acplt.oncrpc
{
	/// <summary>
	/// A collection of constants used to identify the retransmission schemes
	/// when using
	/// <see cref="OncRpcUdpClient">UDP/IP-based ONC/RPC clients</see>
	/// .
	/// </summary>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:43 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcUdpRetransmissionMode
	{
		/// <summary>
		/// In exponentional back-off retransmission mode, UDP/IP-based ONC/RPC
		/// clients first wait a given retransmission timeout period before
		/// sending the ONC/RPC call again.
		/// </summary>
		/// <remarks>
		/// In exponentional back-off retransmission mode, UDP/IP-based ONC/RPC
		/// clients first wait a given retransmission timeout period before
		/// sending the ONC/RPC call again. The retransmission timeout then is
		/// doubled on each try.
		/// </remarks>
		public const int EXPONENTIAL = 0;

		/// <summary>
		/// In fixed retransmission mode, UDP/IP-based ONC/RPC clients wait a
		/// given retransmission timeout period before send the ONC/RPC call again.
		/// </summary>
		/// <remarks>
		/// In fixed retransmission mode, UDP/IP-based ONC/RPC clients wait a
		/// given retransmission timeout period before send the ONC/RPC call again.
		/// The retransmission timeout is not changed between consecutive tries
		/// but is fixed instead.
		/// </remarks>
		public const int FIXED = 1;
	}
}
