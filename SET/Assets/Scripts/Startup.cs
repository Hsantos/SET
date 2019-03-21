using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.engine.utils;
using UnityEngine;

public class Startup : MonoBehaviour
{
    private MenuView menuView;
    private GameView gameview;
    private ClientNetwork clientNetwork;
    private Canvas mainCanvas;
    void Awake()
    {
        MainThread.initiate();
        MainThread.setMainThread();

        mainCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        menuView = mainCanvas.transform.Find("Menu").gameObject.AddComponent<MenuView>();
        clientNetwork = GameObject.Find("ClientNetwork").gameObject.AddComponent<ClientNetwork>();
        menuView.Initiate(clientNetwork);
        menuView.OnSinglePlayerChoose = EnterSinglePlayerGame;
        menuView.OnConnectMultiplayer = EnterMultiPlayerGame;
       
    }

    private void EnterSinglePlayerGame()
    {
        Debug.Log("EnterSinglePlayerGame");
        gameview = mainCanvas.gameObject.AddComponent<GameView>();
        gameview.InitiateView();
        menuView.gameObject.SetActive(false);
    }

    private void EnterMultiPlayerGame()
    {
        Debug.Log("EnterMultiPlayerGame");
        menuView.gameObject.SetActive(false);
        gameview = mainCanvas.gameObject.AddComponent<GameMultiplayerView>();
        clientNetwork.ReceiveServices(gameview);
        ((GameMultiplayerView)gameview).InitiateMultiplayerView(clientNetwork);
       
    }
}
