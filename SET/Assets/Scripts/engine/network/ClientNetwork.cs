using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ClientNetwork
{
    private System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

    public ClientNetwork()
    {
        Connect();
        
    }

    private void Connect()
    {
        Msg("Client Started");

        try
        {
            clientSocket.Connect("192.168.100.14", 1755);
        }
        catch (Exception e)
        {
           Debug.LogError(e);
            throw;
        }

       
        Msg("Client Socket Program - Server Connected ...");
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        NetworkStream serverStream = clientSocket.GetStream();
        byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Simple Client Text"+ "<EOF>");
        serverStream.Write(outStream, 0, outStream.Length);
        serverStream.Flush();

        Debug.Log("clientSocket.ReceiveBufferSize : " + clientSocket.ReceiveBufferSize);


//        byte[] inStream = new byte[clientSocket.ReceiveBufferSize];
//        serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
//        string returndata = System.Text.Encoding.ASCII.GetString(inStream);
//        Msg(returndata);


    }

    public void Msg(string mesg)
    {
        Debug.Log("Client Network" + mesg);
    }

}
