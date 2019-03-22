using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.engine.network.request
{
    [Serializable]
    public class ServerReply
    {
        public RequestAction action;
        public string data;

        public ServerReply(RequestAction action, string data)
        {
            this.action = action;
            this.data = data;
        }
    }
}
