using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.engine.services;
using Assets.Scripts.view.card;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour, GameServices
{
    private GameSession session;
    public Transform board;
    private List<CardView> cardList;
    private List<Card> cardMatch;
    private GameObject prefabCard;
    private Text labelSets;
    private Text labelTime;
    private GridLayoutGroup gridLayout;
    void Awake()
    {
        board = transform.Find("Board").gameObject.transform;
        gridLayout = board.GetComponent<GridLayoutGroup>();
        labelSets = transform.Find("LabelSets").gameObject.GetComponent<Text>();
        labelTime = transform.Find("LabelTime").gameObject.GetComponent<Text>();
        cardList = new List<CardView>();
        prefabCard = Resources.Load<GameObject>("Prefab/card/Card");
        

        session = new GameSession(this);
        UpdateUserSets();
        UpdateUserTime();
        InvokeRepeating(nameof(UpdateUserTime),1,1);
    }

    public void notifyDefaultCards(List<Card> cards)
    {
        Debug.LogWarning("notifyDefaultCards :  "+ cards.Count);
        DrawCard(cards);
    }

    public void notifyOpenCardsAfterMatch(List<Card> cards)
    {
        Debug.LogWarning("notifyOpenCardsAfterMatch :  " + cards.Count);
        DrawCard(cards);
    }

    public void notifyExtraCards(List<Card> cards)
    {
        Debug.LogWarning("notifyExtraCards :  " + cards.Count);
        DrawCard(cards);
    }

    private void DrawCard(List<Card> cards)
    {
        string str = "";
        
        foreach (var t in cards)
        {
            str += t + "\n";
            CardView cv = Instantiate(prefabCard, board).AddComponent<CardView>().Initiate(t);
            cardList.Add(cv);
            cv.onClick.AddListener(() => OnClick(cv));
            cv.enabled = true;
        }

        //Debug.Log("notifyDefaultCards : " + '\n' + str);
        Invoke(nameof(CheckAfterDraw),2f);

        CheckBoardSize();
    }

    public void notifyMatchCompleted(List<Card> cards)
    {
        if (cards != null)
        {
            foreach (var cd in cards)
            {
                foreach (var t in cardList)
                {
                    if (cd == t.card)
                    {
                        cardList.Remove(t);
                        Destroy(t.gameObject);
                    }
                }
            }
        }
        else
        {
            foreach (var t in cardList)
            {
                if(t.gameObject!=null)t.OnClicked(false);
            }
           
        }

        cardMatch = new List<Card>();
        UpdateUserSets();
    }

    public void notifyEndSession()
    {
        Debug.Log("END GAME");
        labelTime.text = "END!";

        CancelInvoke(nameof(CheckAfterDraw));
        CancelInvoke(nameof(UpdateUserTime));

        foreach (var t in cardList)
        {
            cardList.Remove(t);
            Destroy(t.gameObject);
        }
    }

    private void OnClick(CardView cardView)
    {
        Debug.LogWarning("CLICK : " + cardView.card.color);
        if (cardMatch == null || cardMatch.Count==GameSession.TOTAL_CARDS_TO_MATCH) cardMatch = new List<Card>();

        cardView.OnClicked(true);
        cardMatch.Add(cardView.card);

        if (cardMatch.Count == GameSession.TOTAL_CARDS_TO_MATCH)
        {
            session.CheckMatch(cardMatch);
        }
    }

    private void CheckAfterDraw()
    {
        session.CheckAnyMatch();
    }

    private void CheckBoardSize()
    {
        if (cardList.Count<=12)
            gridLayout.cellSize = new Vector2(190,260);
        else
        {
            gridLayout.cellSize = new Vector2(146, 200);
        }
       
    }

    private void UpdateUserSets()
    {
        labelSets.text = "SETS: " + session.userPoints;
    }

    private void UpdateUserTime()
    {
        labelTime.text = "TIME: " + session.UserTime();
    }

}
