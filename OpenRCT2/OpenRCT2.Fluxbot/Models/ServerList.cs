using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRCT2.Fluxbot.Models
{
    public class IP
    {
        [JsonProperty("v4")]
        public List<string> V4 { get; set; }

        [JsonProperty("v6")]
        public List<object> V6 { get; set; }
    }

    public class Provider
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }
    }

    public class GameInfo
    {
        [JsonProperty("mapSize")]
        public int MapSize { get; set; }

        [JsonProperty("day")]
        public int Day { get; set; }

        [JsonProperty("month")]
        public int Month { get; set; }

        [JsonProperty("guests")]
        public int Guests { get; set; }

        [JsonProperty("parkValue")]
        public int ParkValue { get; set; }

        [JsonProperty("cash")]
        public int Cash { get; set; }
    }

    public class Server
    {
        [JsonProperty("ip")]
        public IP IP { get; set; }

        [JsonProperty("port")]
        public int Port { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("requiresPassword")]
        public bool RequiresPassword { get; set; }

        [JsonProperty("players")]
        public int Players { get; set; }

        [JsonProperty("maxPlayers")]
        public int MaxPlayers { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("provider")]
        public Provider Provider { get; set; }

        [JsonProperty("gameInfo")]
        public GameInfo GameInfo { get; set; }
    }

    public class ServerList
    {
        [JsonProperty("servers")]
        public List<Server> Servers { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }
    }
}
