using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    //private GameView gameview;
    private ClientNetwork clientNetwork;
    void Awake()
    {
        //GameObject.Find("Canvas").gameObject.AddComponent<GameView>();
        clientNetwork = new ClientNetwork();
    }
}
