using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Assets.Scripts.engine.game;
using Assets.Scripts.engine.network;
using Assets.Scripts.engine.network.request;
using Assets.Scripts.engine.services;
using Assets.Scripts.engine.utils;
using Newtonsoft.Json;
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
    private string userName;

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

    public void Connect(string ip, string port, string userName)
    {
        serverIp = ip;
        serverPort = port;
        this.userName = userName;

        Debug.Log("Client Started");

        try
        {
            clientSocket.BeginConnect(serverIp, Int32.Parse(serverPort), ConnectCallback, clientSocket);
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

            SendMessageToServer(new ClientRequest(RequestAction.START_SESSION, userName));
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

    private void SendMessageToServer(ClientRequest request)
    {
        string message = JsonConvert.SerializeObject(request);// + "<EOF>";

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

        ServerReply reply = JsonConvert.DeserializeObject<ServerReply>(formatterData);
        ExecuteServerReply(reply);

        receiveDone.Set();
    }

    private void ExecuteServerReply(ServerReply reply)
    {
        switch (reply.action)
        {
            case RequestAction.START_SESSION:
                break;
            case RequestAction.DEFAULT_CARDS:
                List<Card> defaultCards = JsonConvert.DeserializeObject<List<Card>>(reply.data);
                MainThread.invoke(() => gameServices.notifyDefaultCards(defaultCards));
                break;
            case RequestAction.CARDS_AFTER_MATCH:
                List<Card> cardsAfterMatch = JsonConvert.DeserializeObject<List<Card>>(reply.data);
                MainThread.invoke(() => gameServices.notifyOpenCardsAfterMatch(cardsAfterMatch));
                break;
            case RequestAction.EXTRA_CARDS:
                List<Card> extraCardMatch = JsonConvert.DeserializeObject<List<Card>>(reply.data);
                MainThread.invoke(() => gameServices.notifyExtraCards(extraCardMatch));
                break;
            case RequestAction.MATCH:
                List<Card> cardsMatch = JsonConvert.DeserializeObject<List<Card>>(reply.data);
                MainThread.invoke(() => gameServices.notifyMatchCompleted(cardsMatch));
                if (cardsMatch != null) CardsAfterMatchRequest();
                break;
            case RequestAction.END_SESSION:
                ClientRanking ranking = JsonConvert.DeserializeObject<ClientRanking>(reply.data);
                MainThread.invoke(() => gameServices.notifyEndSession(ranking));
                break;
            default:
                throw new Exception("UNKNOWN MESSAGE: " +  reply.action);
        }
    }

    public void DefaultCardsRequest()
    {
        SendMessageToServer(new ClientRequest(RequestAction.DEFAULT_CARDS,""));
        sendDone.WaitOne();

        ReceiveMessageToServer();
        receiveDone.WaitOne();
    }

    public void MatchRequest(List<Card> cards)
    {
        ClientRequest request = new ClientRequest(RequestAction.MATCH, JsonConvert.SerializeObject(cards));
        SendMessageToServer(request);
        sendDone.WaitOne();

        ReceiveMessageToServer();
        receiveDone.WaitOne();
    }

    public void CardsAfterMatchRequest()
    {
        ClientRequest request = new ClientRequest(RequestAction.CARDS_AFTER_MATCH, "");
        SendMessageToServer(request);
        sendDone.WaitOne();

        ReceiveMessageToServer();
        receiveDone.WaitOne();
    }


}
