using Exiled.API.Features;

namespace ExamplePlugin.Events
{
    public class ServerHandler
    {
        public ServerHandler() { }

        // 游戏回合开始
        internal void OnRoundStarted()
        {
            Map.Broadcast(10, "游戏开始!");
        }
    }
}