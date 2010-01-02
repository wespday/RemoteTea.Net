namespace org.acplt.oncrpc
{
	/// <summary>
	/// A collection of constants used for ONC/RPC messages to identify the
	/// remote procedure calls offered by ONC/RPC portmappers.
	/// </summary>
	/// <remarks>
	/// A collection of constants used for ONC/RPC messages to identify the
	/// remote procedure calls offered by ONC/RPC portmappers.
	/// </remarks>
	/// <version>$Revision: 1.1.1.1 $ $Date: 2003/08/13 12:03:41 $ $State: Exp $ $Locker:  $
	/// 	</version>
	/// <author>Harald Albrecht</author>
	public class OncRpcPortmapServices
	{
		/// <summary>Procedure number of portmap service to register an ONC/RPC server.</summary>
		/// <remarks>Procedure number of portmap service to register an ONC/RPC server.</remarks>
		public const int PMAP_SET = 1;

		/// <summary>Procedure number of portmap service to unregister an ONC/RPC server.</summary>
		/// <remarks>Procedure number of portmap service to unregister an ONC/RPC server.</remarks>
		public const int PMAP_UNSET = 2;

		/// <summary>
		/// Procedure number of portmap service to retrieve port number of
		/// a particular ONC/RPC server.
		/// </summary>
		/// <remarks>
		/// Procedure number of portmap service to retrieve port number of
		/// a particular ONC/RPC server.
		/// </remarks>
		public const int PMAP_GETPORT = 3;

		/// <summary>
		/// Procedure number of portmap service to return information about all
		/// currently registered ONC/RPC servers.
		/// </summary>
		/// <remarks>
		/// Procedure number of portmap service to return information about all
		/// currently registered ONC/RPC servers.
		/// </remarks>
		public const int PMAP_DUMP = 4;

		/// <summary>
		/// Procedure number of portmap service to indirectly call a remote
		/// procedure an ONC/RPC server through the ONC/RPC portmapper.
		/// </summary>
		/// <remarks>
		/// Procedure number of portmap service to indirectly call a remote
		/// procedure an ONC/RPC server through the ONC/RPC portmapper.
		/// </remarks>
		public const int PMAP_CALLIT = 5;
	}
}
