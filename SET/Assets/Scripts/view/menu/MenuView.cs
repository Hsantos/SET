using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{

    private Transform mainPanel;
    private Button btMultiplayer;
    private Button btSingle;

    private Transform multiPlayerPanel;
    private Button btConnect;
    private InputField inputIp;
    private InputField inputPort;
    private Text labelStatus;

    public UnityAction OnConnectMultiplayer;
    public UnityAction OnSinglePlayerChoose;

    private bool connectProcess;
   
    private ClientNetwork clientNetwork;
    public enum MENU_STATE
    {
        MAIN,
        MULTIPLAYER
    }

    public void Initiate(ClientNetwork clientNetwork)
    {
        this.clientNetwork = clientNetwork;
    }

    void Awake()
    {
        mainPanel = transform.Find("MainPanel").transform;
        btMultiplayer = mainPanel.transform.Find("BtMultiplayer").GetComponent<Button>();
        btSingle = mainPanel.transform.Find("BtSingle").GetComponent<Button>();

        multiPlayerPanel = transform.Find("MultiplayerPanel").transform;
        inputIp = multiPlayerPanel.Find("InputIp").GetComponent<InputField>();
        inputPort = multiPlayerPanel.Find("InputPort").GetComponent<InputField>();
        btConnect = multiPlayerPanel.Find("BtConnect").GetComponent<Button>();
        labelStatus = multiPlayerPanel.Find("LabelStatus").GetComponent<Text>();

        btSingle.onClick.AddListener(()=>OnSinglePlayerChoose?.Invoke());
        btMultiplayer.onClick.AddListener(()=> ChangeState(MENU_STATE.MULTIPLAYER));

        btConnect.onClick.AddListener(OnTryConnectClient);
        connectProcess = false;

        ChangeState(MENU_STATE.MAIN);
    }

    private void ChangeState(MENU_STATE state)
    {
        switch (state)
        {
            case MENU_STATE.MAIN:
                mainPanel.gameObject.SetActive(true);
                multiPlayerPanel.gameObject.SetActive(false);

                inputIp.text = "192.168.100.0";
                inputPort.text = "0000";
                labelStatus.text = "";

                break;
            case MENU_STATE.MULTIPLAYER:
                mainPanel.gameObject.SetActive(false);
                multiPlayerPanel.gameObject.SetActive(true);
                break;
            default:
                throw  new Exception("UNKNOWN MENU STATE: " +  state);
        }
    }

    private void OnTryConnectClient()
    {
        if (connectProcess) return;
        Debug.Log("Init Process");
        btConnect.gameObject.SetActive(false);
        labelStatus.text = "Wait Connecting...";
        clientNetwork.OnClientConnected = OnConnectionCallback;
        clientNetwork.Connect(inputIp.text, inputPort.text);
        connectProcess = true;
        
    }

    private void OnConnectionCallback()
    {
        connectProcess = false;
        labelStatus.text = "Client Connected!";
        Invoke(nameof(SendCallbackConnection), 2f);
    }

    public void SendCallbackConnection()
    {
       OnConnectMultiplayer?.Invoke();
    }
}
