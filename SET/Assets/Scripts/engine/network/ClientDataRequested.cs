using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.engine.network
{
    [Serializable]
    public class ClientDataRequested
    {
        public List<Card> cards;
    }
}
