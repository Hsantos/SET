using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Assets.Scripts.engine.network.request
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestAction
    {
        START_SESSION,
        DEFAULT_CARDS,
        CARDS_AFTER_MATCH,
        MATCH,
        EXTRA_CARDS,
        END_SESSION
    }
}
