using System;
using System.Collections.Generic;


namespace Assets.Scripts.engine.game
{
    [Serializable]
    public class ClientRanking
    {
        public List<ClientPoint> list;

        public ClientRanking(List<ClientPoint> list)
        {
            this.list = list;
        }
    }
}
