using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.engine.services;

public class GameSession
{
    private SessionBehaviour behaviour;
    private List<Card> cardSession;
    private GameServices services;
    public const  int TOTAL_CARDS_IN_DEFAULT_ROUND = 12;
    public const  int TOTAL_CARDS_IN_EXTRA_ROUND = 12;
    public const  int TOTAL_CARDS_TO_MATCH = 3;

    public GameSession(GameServices services)
    {
        this.services = services;
        behaviour = new SessionBehaviour();
        cardSession = behaviour.GenerateShuffleCard().ToList();
        OpenDefaultCards();
    }

    private void OpenDefaultCards()=> services.notifyDefaultCards(OpenCards(TOTAL_CARDS_IN_DEFAULT_ROUND));
    public void OpenCardsAfterMatch(int totalToOpen)=> services.notifyOpenCardsAfterMatch(OpenCards(totalToOpen));
    public void OpenExtraCards()=> services.notifyExtraCards(OpenCards(TOTAL_CARDS_IN_EXTRA_ROUND));

    private List<Card> OpenCards(int total)
    {
        List<Card> openedList = new List<Card>();
        for (int i = 0; i < total; i++)
        {
            openedList.Add(cardSession[i]);
            cardSession.RemoveAt(i);
        }

        return openedList;
    }

    public void CheckMatch(List<Card> matchList)
    {
//        behaviour.IsMatch(matchList);
//        services.notifyMatchCompleted(null);

        if (behaviour.IsMatch(matchList)) services.notifyMatchCompleted(matchList);
        else services.notifyMatchCompleted(null);
    }
}
