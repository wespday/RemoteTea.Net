using org.acplt.oncrpc.server;
using org.acplt.oncrpc;
using System;
using System.Net;
using System.Threading;
namespace tests.org.acplt.oncrpc
{
    public class ServerTest : OncRpcDispatchable
    {
        /*
		public class ShutdownHookThread : java.lang.Thread
		{
			private tests.org.acplt.oncrpc.ServerTest svr;

			public ShutdownHookThread(ServerTest _enclosing, tests.org.acplt.oncrpc.ServerTest
				 svr)
			{
				this._enclosing = _enclosing;
				this.svr = svr;
			}

			public override void run()
			{
				System.Console.Out.WriteLine("Shutdown Hook Thread activated");
				this.svr.shutdown();
			}

			private readonly ServerTest _enclosing;
		}
        */

        public object leaveTheStage = new object();

        public int shorthandCredCounter = 0;

        /// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        public ServerTest()
        {
            //
            // Flag to signal shut down of the server.
            //
            //
            // Shorthand credential use counter.
            //
            //
            //
            //
            OncRpcUdpServerTransport udpTrans = new OncRpcUdpServerTransport
                (this, 55555, unchecked((int)(0x49679)), 1, 8192);
            OncRpcTcpServerTransport tcpTrans = new OncRpcTcpServerTransport
                (this, 55555, unchecked((int)(0x49679)), 1, 8192);
            //java.lang.Runtime.getRuntime().addShutdownHook(new tests.org.acplt.oncrpc.ServerTest.ShutdownHookThread
            //	(this, this));
            udpTrans.register();
            tcpTrans.register();
            System.Console.Out.WriteLine("Server started.");
            tcpTrans.listen();
            udpTrans.listen();
            //
            // Reality Check: open a connection to the TCP/IP server socket
            // waiting for incoming connection, thus testing proper shutdown
            // behaviour later...
            //
            OncRpcTcpClient client = new OncRpcTcpClient(IPAddress.Loopback,
            unchecked((int)(0x49679)), 1, 0);
            //
            // Now wait for the shutdown to become signalled... Note that
            // a simple call to wait() without the outer loop would not be
            // sufficient as we might get spurious wake-ups due to
            // interruptions.
            //
            for (; ; )
            {
                lock (leaveTheStage)
                {
                    try
                    {
                        Monitor.Wait(leaveTheStage);
                        break;
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }
            Console.Out.WriteLine("Server shutting down...");
            //
            // Unregister TCP-based transport. Then close it. This will
            // also automatically bring down the threads handling individual
            // TCP transport connections.
            //
            tcpTrans.unregister();
            tcpTrans.Close();
            //
            // Unregister UDP-based transport. Then close it.  This will
            // automatically bring down the thread which handles the
            // UDP transport.
            //
            udpTrans.unregister();
            udpTrans.Close();
            Console.Out.WriteLine("Server shut down.");
        }

        //
        // Indicate that the server should be shut down. Sad enough that the
        // Java Environment can not cope with signals. I know that they're not
        // universially available -- but why shouldn't be there a class providing
        // this functionality and in case the runtime environment does not support
        // sending and receiving signals, it either throws an exception or gives
        // some indication otherwise. It wouldn't be bad and we would be sure
        // that the appropriate class is always available.
        //
        public virtual void shutdown()
        {
            if (leaveTheStage != null)
            {
                System.Console.Out.WriteLine("Requesting server to shut down...");
                lock (leaveTheStage)
                {
                    Monitor.PulseAll(leaveTheStage);
                }
            }
        }

        //
        // Handle incomming calls...
        //
        /// <exception cref="org.acplt.oncrpc.OncRpcException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        public virtual void dispatchOncRpcCall(OncRpcCallInformation
             call, int program, int version, int procedure)
        {
            //
            // Spit out some diagnosis messages...
            //
            System.Console.Out.WriteLine("Incomming call for program " + program.ToString("X")
                + "; version " + version + "; procedure " + procedure.ToString("X") + "; auth type "
                 + call.callMessage.auth.getAuthenticationType());
            //
            // Handle incomming credentials...
            //
            if (call.callMessage.auth.getAuthenticationType() == OncRpcAuthType
                .ONCRPC_AUTH_UNIX)
            {
                OncRpcServerAuthUnix auth = (OncRpcServerAuthUnix
                    )call.callMessage.auth;
                if ((auth.uid != 42) && (auth.gid != 815))
                {
                    throw (new OncRpcAuthenticationException(OncRpcAuthStatus
                        .ONCRPC_AUTH_BADCRED));
                }
                //
                // Suggest shorthand authentication...
                //
                XdrBufferEncodingStream xdr = new XdrBufferEncodingStream(8);
                xdr.beginEncoding(null, 0);
                xdr.xdrEncodeInt(42);
                xdr.xdrEncodeInt(~42);
                xdr.endEncoding();
                //
                // ATTENTION: this will return the *whole* buffer created by the
                // constructor of XdrBufferEncodingStream(len) above. So make sure
                // that you really want to return the whole buffer!
                //
                auth.setShorthandVerifier(xdr.getXdrData());
            }
            else
            {
                if (call.callMessage.auth.getAuthenticationType() == OncRpcAuthType
                    .ONCRPC_AUTH_SHORT)
                {
                    //
                    // Check shorthand credentials.
                    //
                    OncRpcServerAuthShort auth = (OncRpcServerAuthShort)call.callMessage.auth;
                    XdrBufferDecodingStream xdr = new XdrBufferDecodingStream
                        (auth.getShorthandCred());
                    xdr.beginDecoding();
                    int credv1 = xdr.xdrDecodeInt();
                    int credv2 = xdr.xdrDecodeInt();
                    xdr.endDecoding();
                    if (credv1 != ~credv2)
                    {
                        Console.Out.WriteLine("AUTH_SHORT rejected");
                        throw (new OncRpcAuthenticationException(OncRpcAuthStatus.ONCRPC_AUTH_REJECTEDCRED));
                    }
                    if ((++shorthandCredCounter % 3) == 0)
                    {
                        System.Console.Out.WriteLine("AUTH_SHORT too old");
                        throw (new OncRpcAuthenticationException(OncRpcAuthStatus
                            .ONCRPC_AUTH_REJECTEDCRED));
                    }
                    Console.Out.WriteLine("AUTH_SHORT accepted");
                }
            }
            switch (procedure)
            {
                case 0:
                    {
                        //
                        // Now dispatch incomming calls...
                        //
                        //
                        // The usual ONC/RPC PING (aka "NULL" procedure)
                        //
                        call.retrieveCall(XdrVoid.XDR_VOID);
                        call.reply(XdrVoid.XDR_VOID);
                        break;
                    }

                case 1:
                    {
                        //
                        // echo string parameter
                        //
                        XdrString param = new XdrString();
                        call.retrieveCall(param);
                        System.Console.Out.WriteLine("Parameter: \"" + param.stringValue() + "\"");
                        call.reply(param);
                        break;
                    }

                case 42:
                    {
                        //
                        // This is a special call to shut down the server...
                        //
                        if ((program == 42) && (version == 42))
                        {
                            call.retrieveCall(XdrVoid.XDR_VOID);
                            call.reply(XdrVoid.XDR_VOID);
                            shutdown();
                            break;
                        }
                        break;
                    }

                default:
                    {
                        //
                        // For all unknown calls, send back an error reply.
                        //
                        call.failProcedureUnavailable();
                        break;
                    }
            }
        }

        public static void Main(string[] args)
        {
            Console.Out.WriteLine("ServerTest");
            try
            {
                new ServerTest();
            }
            catch (System.Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
            }
        }
    }
}
