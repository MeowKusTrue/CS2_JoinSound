using CounterStrikeSharp.API.Core;
using System.Text.Json.Serialization;

namespace CS2_JoinSound
{
    public class PluginConfig : BasePluginConfig
    {
        [JsonPropertyName("path")]
        public string MusicFile { get; set; } = "dpmusic3/d1.vsnd";
    }
}
