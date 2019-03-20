using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Assets.Scripts.engine.network;
using Assets.Scripts.engine.services;
using Assets.Scripts.engine.utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class ClientNetwork:MonoBehaviour, NetworkServices
{
    private TcpClient clientSocket;
    private NetworkStream serverStream;
    private static ManualResetEvent connectDone;
    private static ManualResetEvent sendDone;
    private static ManualResetEvent receiveDone;
    private Socket socket;
    private static String response = String.Empty;

    private string serverIp;
    private string serverPort;

    public UnityAction OnClientConnected;

    private GameServices gameServices;
    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 256;
        public byte[] buffer = new byte[BufferSize];
        public StringBuilder sb = new StringBuilder();
    }

    //"192.168.100.14", 1755
    void Awake()
    {
        clientSocket = new TcpClient();
        connectDone = new ManualResetEvent(false);
        sendDone = new ManualResetEvent(false);
        receiveDone = new ManualResetEvent(false);
    }

    public void ReceiveServices(GameServices services)
    {
        this.gameServices = services;
    }

    public void Connect(string ip, string port)
    {
        serverIp = ip;
        serverPort = port;

        Debug.Log("Client Started");

        try
        {
            clientSocket.BeginConnect("192.168.100.14", 1755, new AsyncCallback(ConnectCallback), clientSocket);
            connectDone.WaitOne();
            
        }
        catch (Exception e)
        {
           Debug.LogError(e);
            throw;
        }

    }

    private void ConnectCallback(IAsyncResult ar)
    {
        try
        {
//            Msg("Socket connected to {0}" + ar);
            
            serverStream = clientSocket.GetStream();
            connectDone.Set();

            SendMessageToServer(RequestType.CONNECTION);
            sendDone.WaitOne();
            //
            ReceiveMessageToServer();
            MainThread.invoke(() => OnClientConnected());

            receiveDone.WaitOne();

        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    private void SendMessageToServer(string msg)
    {
        string message = msg;// + "<EOF>";

        Debug.Log("SendMessageToServer : " + message);

        byte[] outStream = Encoding.ASCII.GetBytes(message);
        serverStream.Write(outStream, 0, outStream.Length);
        serverStream.Flush();
        sendDone.Set();

    }

    private void ReceiveMessageToServer()
    {
        byte[] inStream = new byte[clientSocket.ReceiveBufferSize];
        serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
        string returnData = Encoding.ASCII.GetString(inStream);
        string formatterData = returnData.IndexOf("<EOF>", StringComparison.Ordinal) > -1 ? returnData.Replace("<EOF>", "") : returnData;

        Debug.Log("ReceiveMessageToServer: " + formatterData);

        if (formatterData.Contains("{"))
        {
            TryParser(formatterData);
           
        }
        else
        {
            Debug.Log("do nothing ");
        }
       
        receiveDone.Set();
    }

    private void TryParser(string returnData)
    {
        ClientDataRequested data  = JsonUtility.FromJson<ClientDataRequested>(returnData);
        MainThread.invoke(() => gameServices.notifyDefaultCards(data.cards));
    }

    public void DefaultCardsRequest()
    {
        SendMessageToServer(RequestType.DEFAULT_CARDS);
        sendDone.WaitOne();

        ReceiveMessageToServer();
        receiveDone.WaitOne();
    }
}
