﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.engine.services
{
    public interface GameServices
    {
        void notifyDefaultCards(List<Card> cards);
        void notifyOpenCardsAfterMatch(List<Card> cards);
        void notifyExtraCards(List<Card> cards);
        void notifyMatchCompleted(List<Card> cards);
    }
}
