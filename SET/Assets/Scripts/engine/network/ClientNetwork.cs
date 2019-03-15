using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

public class ClientNetwork
{
    private TcpClient clientSocket;
//    private Socket clientSocket;
    private NetworkStream serverStream;
    private static ManualResetEvent connectDone;
    private static ManualResetEvent sendDone;
    private static ManualResetEvent receiveDone;
    private Socket socket;
    private static String response = String.Empty;

    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public ClientNetwork()
    {
        clientSocket = new TcpClient();
        connectDone = new ManualResetEvent(false);
        sendDone = new ManualResetEvent(false);
        receiveDone = new ManualResetEvent(false);

        Connect();        
    }

    private void Connect()
    {
        Msg("Client Started");

        try
        {
            clientSocket.BeginConnect("192.168.100.14", 1755, new AsyncCallback(ConnectCallback), clientSocket);
//            socket = new Socket();
//            socket.BeginConnect("192.168.100.14", 1755, new AsyncCallback(ConnectCallback), clientSocket);
            connectDone.WaitOne();
            
        }
        catch (Exception e)
        {
           Debug.LogError(e);
            throw;
        }

       
        Msg("Client Socket Program - Server Connected ...");

    }

    private void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            //socket = (Socket)ar.AsyncState;
            //socket.EndConnect(ar);
            Msg("Socket connected to {0}" + ar);
            serverStream = clientSocket.GetStream();
            connectDone.Set();
            SendMessageToServer("Simple Client Text");
            sendDone.WaitOne();
            //
            ReceiveMessageToServer();
//            Receive(socket);
            receiveDone.WaitOne();
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    private void SendMessageToServer(string msg)
    {
        msg +=  "<EOF>";
        byte[] outStream = System.Text.Encoding.ASCII.GetBytes(msg);
        serverStream.Write(outStream, 0, outStream.Length);
        serverStream.Flush();
        sendDone.Set();

    }

    private void ReceiveMessageToServer()
    {
        byte[] inStream = new byte[clientSocket.ReceiveBufferSize];
        serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
        string returnData = System.Text.Encoding.ASCII.GetString(inStream);
        Msg("ReceiveMessageToServer: " +  returnData);
    }

    private void Receive(Socket client)
    {
        try
        {
            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = client;

            Msg("Client Receive from server: " + response);

            // Begin receiving the data from the remote device.  
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,new AsyncCallback(ReceiveCallback), state);
        }
        catch (Exception e)
        {
           Debug.LogError(e.ToString());
        }
    }

    private void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the state object and the client socket   
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;

            // Read data from the remote device.  
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                // Get the rest of the data.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            else
            {
                // All the data has arrived; put it in response.  
                if (state.sb.Length > 1)
                {
                    response = state.sb.ToString();
                    Msg("Client receive callback from server: " + response);
                }
                // Signal that all bytes have been received.  
                receiveDone.Set();
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    public void Msg(string msg)
    {
        Debug.Log("Client Network" + msg);
    }

}
