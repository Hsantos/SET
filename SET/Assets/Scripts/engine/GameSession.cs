using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Assets.Scripts.engine.services;
using UnityEngine.Diagnostics;
using Debug = UnityEngine.Debug;

public class GameSession
{
    private SessionBehaviour behaviour;
    private List<Card> cardSession;
    private GameServices services;
    public const  int TOTAL_CARDS_IN_DEFAULT_ROUND = 12;
    public const  int TOTAL_CARDS_IN_EXTRA_ROUND = 3;
    public const  int TOTAL_CARDS_TO_MATCH = 3;

    private List<Card> openedList;
    public GameSession(GameServices services)
    {
        this.services = services;
        behaviour = new SessionBehaviour();
        cardSession = behaviour.GenerateShuffleCard().ToList();
        OpenDefaultCards();
        CheckAnyMatch();
    }

    private void OpenDefaultCards()
    {
        openedList = new List<Card>();
        services.notifyDefaultCards(OpenCards(TOTAL_CARDS_IN_DEFAULT_ROUND));
    }

    public void OpenCardsAfterMatch(int totalToOpen)
    {
        List<Card> cardsToOpen = OpenCards(totalToOpen);
        if(cardsToOpen!=null)services.notifyOpenCardsAfterMatch(cardsToOpen);
        else services.notifyEndSession();
    }

    public void OpenExtraCards()
    {
        List<Card> cardsToOpen = OpenCards(TOTAL_CARDS_IN_EXTRA_ROUND);
        if (cardsToOpen != null) services.notifyExtraCards(cardsToOpen);
        else services.notifyEndSession();
    }

    private List<Card> OpenCards(int total)
    {
        int countCards = total <= cardSession.Count ? total : cardSession.Count;
        if (countCards == 0) return null;

        for (int i = 0; i < total; i++)
        {
            openedList.Add(cardSession[i]);
            cardSession.Remove(cardSession[i]);
        }

        return openedList;
    }

    public void CheckMatch(List<Card> matchList)
    {
//        behaviour.IsMatch(matchList);
//        services.notifyMatchCompleted(null);

        if (behaviour.IsMatch(matchList))
        {
            for (int i = 0; i < matchList.Count; i++)
            {
                openedList.Remove(matchList[i]);
            }
            services.notifyMatchCompleted(matchList);
            OpenCardsAfterMatch(matchList.Count);
        }
        else services.notifyMatchCompleted(null);
    }

    public void CheckAnyMatch()
    {
        bool anyMatch = false;

        List<Card> cardChecked = new List<Card>();
        for (int i = 0; i < openedList.Count; i++)
        {
            Card cardOne = openedList[i];
           
            for (int j = 0; j < openedList.Count; j++)
            {
                if(i==j) continue;
                
                Card cardTwo = openedList[GetIndex(j)];
                Card cardThree = openedList[GetIndex(j+1)];

                if (behaviour.IsMatch(new List<Card>(){cardOne, cardTwo, cardThree}))
                {
                    Debug.LogWarning("POSSIBLE MATCH: " + cardOne + " | " +  cardTwo +  " | " + cardThree);
                    anyMatch = true;
                }
            }
                
        }

        Debug.LogWarning("ANY MATCH: " + anyMatch);
        if (!anyMatch) OpenExtraCards();
    }

    private int GetIndex(int index)
    {
        if(index >= openedList.Count) return 0;
        return index;
    }
}
