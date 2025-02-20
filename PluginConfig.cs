using CounterStrikeSharp.API.Core;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace CS2_JoinSound
{
    public class PluginConfig : BasePluginConfig
    {
        [JsonPropertyName("soundMode")]
        public string SoundMode { get; set; } = "order"; // random or order

        [JsonPropertyName("musicList")]
        public List<SoundItem> MusicList { get; set; } = new List<SoundItem>
        {
            new SoundItem { Path = "dpmusic3/d1.vsnd" },
            new SoundItem { Path = "dpmusic3/d2.vsnd" }
        };
    }

    public class SoundItem
    {
        [JsonPropertyName("path")]
        public string Path { get; set; } = "dpmusic3/d1.vsnd"; // Default path
    }
}