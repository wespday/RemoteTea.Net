namespace org.acplt.oncrpc.server
{
	/// <summary>
	/// The class <code>OncRpcServerTransportRegistrationInfo</code> holds
	/// information about (possibly multiple) registration of server transports
	/// for individual program and version numbers.
	/// </summary>
	/// <remarks>
	/// The class <code>OncRpcServerTransportRegistrationInfo</code> holds
	/// information about (possibly multiple) registration of server transports
	/// for individual program and version numbers.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $State: Exp $ $Locker:  $</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcServerTransportRegistrationInfo
	{
		/// <param name="program">
		/// Number of ONC/RPC program handled by a server
		/// transport.
		/// </param>
		/// <param name="version">Version number of ONC/RPC program handled.</param>
		public OncRpcServerTransportRegistrationInfo(int program, int version)
		{
			this.program = program;
			this.version = version;
		}

		/// <summary>Number of ONC/RPC program handled.</summary>
		/// <remarks>Number of ONC/RPC program handled.</remarks>
		public int program;

		/// <summary>Version number of ONC/RPC program handled.</summary>
		/// <remarks>Version number of ONC/RPC program handled.</remarks>
		public int version;
	}
}
