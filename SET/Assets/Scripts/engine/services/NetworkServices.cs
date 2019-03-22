using System.Collections.Generic;

namespace Assets.Scripts.engine.services
{
    public interface NetworkServices
    {
        void DefaultCardsRequest();
        void MatchRequest(List<Card> cards);
    }
}
