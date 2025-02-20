using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Entities;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CS2_JoinSound
{
    public class JoinSound : BasePlugin, IPluginConfig<PluginConfig>
    {
        public override string ModuleName => "CS2_JoinSound";
        public override string ModuleVersion => "0.0.2";
        public override string ModuleAuthor => "MeowKus";

        public PluginConfig Config { get; set; } = new PluginConfig();

        private Dictionary<CCSPlayerController, int> playerSoundIndex = new Dictionary<CCSPlayerController, int>();

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
                PlaySound(player);
            }
            else
            {
                Console.WriteLine($"Player with slot {playerSlot} not found.");
            }
        }

        private void PlaySound(CCSPlayerController player)
        {
            try
            {
                string soundPath = GetSoundPath(Config.SoundMode, Config.MusicList, player);
                if (!string.IsNullOrEmpty(soundPath))
                {
                    player.ExecuteClientCommand($"play {soundPath}");
                    Console.WriteLine($"Playing sound for player: {soundPath}");
                }
                else
                {
                    Console.WriteLine($"No sound found for play event.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while playing sound: {ex.Message}");
            }
        }

        private string GetSoundPath(string mode, List<SoundItem> soundList, CCSPlayerController player)
        {
            if (soundList.Count == 0) return string.Empty;

            if (mode == "random")
            {
                Random random = new Random();
                int index = random.Next(soundList.Count);
                return soundList[index].Path;
            }
            else // "order"
            {
                if (!playerSoundIndex.ContainsKey(player))
                {
                    playerSoundIndex[player] = 0;
                }

                int currentIndex = playerSoundIndex[player];
                string soundPath = soundList[currentIndex].Path;

                playerSoundIndex[player] = (currentIndex + 1) % soundList.Count;

                return soundPath;
            }
        }

        [ConsoleCommand("jtest")]
        public void PlayJoinCommand(CCSPlayerController controller, CommandInfo info)
        {
            PlaySound(controller);
        }
    }
}