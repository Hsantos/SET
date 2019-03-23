using System.Collections.Generic;
using Assets.Scripts.engine.game;
using Assets.Scripts.engine.services;
using Assets.Scripts.view.card;
using UnityEngine;
using UnityEngine.UI;

public class GameMultiplayerView : GameView, GameServices
{
    private GameSession session;
    public Transform board;
    private List<CardView> cardList;
    private List<Card> cardMatch;
    private GameObject prefabCard;
    private Text labelSets;
    private Text labelTime;
    private GridLayoutGroup gridLayout;

    private bool isMultiPlayer = false;
    private NetworkServices network;
    void Awake()
    {
        board = transform.Find("Board").gameObject.transform;
        gridLayout = board.GetComponent<GridLayoutGroup>();
        labelSets = transform.Find("LabelSets").gameObject.GetComponent<Text>();
        labelTime = transform.Find("LabelTime").gameObject.GetComponent<Text>();
        cardList = new List<CardView>();
        prefabCard = Resources.Load<GameObject>("Prefab/card/Card");
    }

    public void InitiateMultiplayerView(NetworkServices network)
    {
        this.network = network;
        network.DefaultCardsRequest();
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

        foreach (Card t in cards)
        {
            str += t + "\n";
            CardView cv = Instantiate(prefabCard, board).AddComponent<CardView>().Initiate(t);
            cardList.Add(cv);
            cv.onClick.AddListener(() => OnClick(cv));
            cv.enabled = true;
        }
    }

    public void notifyMatchCompleted(List<Card> cards)
    {
        Debug.LogWarning("notifyMatchCompleted :  " +  cards.Count +  " | " + cardList.Count);

        if (cards != null)
        {
            foreach (var cd in cards)
            {
                foreach (var t in cardList)
                {
                    if (!cd.Equals(t.card)) continue;
                    cardList.Remove(t);
                    Destroy(t.gameObject);
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
    }

    public void notifyEndSession(ClientRanking ranking)
    {
        Debug.Log("END GAME");

        if(ranking==null) labelTime.text = "END!";
        else
        {
            string result = "END!";
            for (int i = 0; i < ranking.list.Count; i++)
            {
                result += '\n' + ranking.list[i].name + " : " + ranking.list[i].points;
            }

            labelTime.text = result;
        }


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
            network.MatchRequest(cardMatch);
//            if (session.IsMatch(cardMatch)) network.MatchRequest(cardMatch);
//            else
//            {
//                ResetCardSelected(cardMatch);
//                cardMatch.Clear();
//            }
        }
    }

    private void ResetCardSelected(List<Card> cardsSelected)
    {
        foreach (var c in cardsSelected)
        {
            foreach (var t in cardList)
            {
                if (t?.card == c)
                {
                    t.OnClicked(false);
                }
            }
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
