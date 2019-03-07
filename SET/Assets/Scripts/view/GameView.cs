using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.engine.services;
using Assets.Scripts.view.card;
using UnityEngine;

public class GameView : MonoBehaviour, GameServices
{
    private GameSession session;
    public Transform board;
    private List<CardView> cardList;
    private List<Card> cardMatch;
    
    void Awake()
    {
        board = transform.Find("Board").gameObject.transform;
        cardList = new List<CardView>();
        session = new GameSession(this);
    }

    public void notifyDefaultCards(List<Card> cards)
    {
        string str = "";
        GameObject prefab = Resources.Load<GameObject>("Prefab/card/Card");
        for (int i = 0; i < cards.Count; i++)
        {
            str += cards[i] + "\n";
            CardView cv = Instantiate(prefab, board).AddComponent<CardView>().Initiate(cards[i]);
            cardList.Add(cv);
            cv.onClick.AddListener(() => OnClick(cv));

        }

        Debug.Log("notifyDefaultCards : " +  '\n' +  str);
    }

    public void notifyOpenCardsAfterMatch(List<Card> cards)
    {
        throw new System.NotImplementedException();
    }

    public void notifyExtraCards(List<Card> cards)
    {
        throw new System.NotImplementedException();
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
                        Destroy(t.gameObject);
                    }
                }
            }
        }
        else
        {
            
            foreach (var t in cardList) t.OnClicked(false);
           
        }

        cardMatch = new List<Card>();
    }

    private void OnClick(CardView cardView)
    {
        if (cardMatch == null || cardMatch.Count==GameSession.TOTAL_CARDS_TO_MATCH) cardMatch = new List<Card>();

        cardView.OnClicked(true);
        cardMatch.Add(cardView.card);

        if (cardMatch.Count == GameSession.TOTAL_CARDS_TO_MATCH)
        {
            session.CheckMatch(cardMatch);
        }
    }
}
