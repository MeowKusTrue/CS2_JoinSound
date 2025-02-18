using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text.Json;

namespace CS2_JoinSound
{
    public class JoinSound : BasePlugin, IPluginConfig<PluginConfig>
    {
        public override string ModuleName => "JoinSound";
        public override string ModuleVersion => "0.0.1";
        public override string ModuleAuthor => "MeowKus";

        public PluginConfig Config { get; set; } = new PluginConfig();

        public void OnConfigParsed(PluginConfig config)
        {
            Config = config;
            Console.WriteLine("Configuration loaded successfully.");
        }

        public override void Load(bool hotReload)
        {
            base.Load(hotReload);

            RegisterListener<Listeners.OnClientPutInServer>(OnClientPutInServer);
        }

        private void OnClientPutInServer(int playerSlot)
        {
            var player = Utilities.GetPlayerFromSlot(playerSlot);
            if (player != null)
            {
                PlayJoinSound(player);
            }
            else
            {
                Console.WriteLine($"Player with slot {playerSlot} not found.");
            }
        }

        private void PlayJoinSound(CCSPlayerController player)
        {
            try
            {
                string musicFile = Config?.MusicFile ?? "default_sound_path.vsnd";
                player.ExecuteClientCommand($"play {musicFile}");

                Console.WriteLine($"Playing music for player");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while playing music: {ex.Message}");
            }
        }

        [ConsoleCommand("play_music")]
        public void PlayMusicCommand(CCSPlayerController controller, CommandInfo info)
        {
            PlayJoinSound(controller);
        }
    }
}
