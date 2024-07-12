using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using ExamplePlugin.Events;

namespace ExamplePlugin
{
    internal class ExamplePlugin : Plugin<Config>
    {
        public ExamplePlugin() { }

        public static ExamplePlugin Singleton { get; private set; } = new ExamplePlugin();

        public override string Author { get; } = "l4kkS41";

        public override string Name { get; } = "萌新天堂服务器插件v1.0.0";

        public override PluginPriority Priority { get; } = PluginPriority.Default;

        public Harmony Harmony { get; private set; }

        MapHandler MapHandler;

        PlayerHandler PlayerHandler;

        ServerHandler ServerHandler;

        public override void OnEnabled()
        {
            Harmony = new Harmony("l4kkS41.HarmonyPatch");
            Harmony.PatchAll();

            MapHandler = new MapHandler();
            PlayerHandler = new PlayerHandler();
            ServerHandler = new ServerHandler();

            // MapHandler
            Exiled.Events.Handlers.Map.PlacingBlood += MapHandler.OnPlacingBlood;

            // PlayerHandler
            Exiled.Events.Handlers.Player.Verified += PlayerHandler.OnVerified;

            // ServerHandler
            Exiled.Events.Handlers.Server.RoundStarted += ServerHandler.OnRoundStarted;

            Log.Info($"{this.Name} Has Been Loaded Successfully :)");

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            // MapHandler
            Exiled.Events.Handlers.Map.PlacingBlood -= MapHandler.OnPlacingBlood;

            // PlayerHandler
            Exiled.Events.Handlers.Player.Verified -= PlayerHandler.OnVerified;

            // ServerHandler
            Exiled.Events.Handlers.Server.RoundStarted -= ServerHandler.OnRoundStarted;

            MapHandler = null;
            PlayerHandler = null;
            ServerHandler = null;

            Log.Info($"{this.Name} Has Been Disabled :(");

            base.OnDisabled();
        }

        public override void OnReloaded()
        {
            base.OnReloaded();
        }
    }
}